<template>
  <simple-layout>
    <div class="w-[30rem] mx-auto mt-10">
      <div class="bg-blue-500 h-10 flex content-center">
        <span class="mx-auto my-auto text-center text-white font-bold">
          Agendar
        </span>
      </div>
      <form class="divide-y-2 flex flex-col justify-around px-2 bg-gray-100" :disabled="searched" @submit.prevent="submit">
        <div class="flex flex-row py-2 justify-center space-x-2 w-full">
          <input v-model="reservation.fecha" class="input" type="date" placeholder="Fecha">
          <input v-model="reservation.hora" class="input" type="time" placeholder="Hora">
        </div>
        <div class="flex flex-row justify-between space-x-1 py-2">
          <input v-model="reservation.patient.mail" class="input w-full" type="mail" placeholder="Correo">
          <button class="action-button" type="button" @click="search">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="m-auto h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              stroke-width="2"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
            </svg>
          </button>
          <button class="action-button" type="button" :disabled="!searched" @click="add">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="m-auto h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              stroke-width="2"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z" />
            </svg>
          </button>
        </div>
        <div class="flex flex-row justify-between space-x-1 py-2">
          <input v-model="reservation.patient.nombre" class="input w-full" type="text" placeholder="Nombre" :disabled="readonly">
        </div>
        <div class="flex flex-row justify-between space-x-1 py-2">
          <input v-model="reservation.patient.apellidoPaterno" class="input w-1/2" type="text" placeholder="Apellido Paterno" :disabled="readonly">
          <input v-model="reservation.patient.apellidoMaterno" class="input w-1/2" type="text" placeholder="Apellido Materno" :disabled="readonly">
        </div>
        <div class="flex flex-row justify-around space-x-1 py-2">
          <button class="form-button w-1/2 bg-blue-500 hover:bg-blue-600" type="button" @click="back">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="my-auto h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              stroke-width="2"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
            </svg>
            <span class="my-auto">
              Regresar
            </span>
          </button>
          <button class="form-button w-1/2 bg-green-500 hover:bg-green-600" type="submit" :disabled="!searched">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="my-auto h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              stroke-width="2"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M8 7H5a2 2 0 00-2 2v9a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2h-3m-1 4l-3 3m0 0l-3-3m3 3V4" />
            </svg>
            <span class="my-auto">
              Guardar
            </span>
          </button>
        </div>
      </form>
    </div>
  </simple-layout>
</template>

<script>
import SimpleLayout from '@/layouts/simple-layout.vue'
export default {
  components: {
    SimpleLayout
  },
  data() {
    return {
      readonly: true,
      searched: false,
      reservation: {
        id: 0,
        fecha: '',
        hora: 0,
        patient: {
          idParteRole: 0,
          mail: '',
          nombre: '',
          apellidoPaterno: '',
          apellidoMaterno: ''
        }
      }
    }
  },
  mounted() {
    this.reservation.fecha = this.$route.query.fecha
    this.reservation.hora = this.$route.query.horario
  },
  methods: {
    submit() {
      this.$vToastify.prompt({
        body: '¿Está seguro de agendar?',
        answers: { Yes: true, No: false }
      }).then((value) => {
        if (value) {
          this.save()
        }
      })
    },
    async save() {
      const _proccessId = this.$vToastify.loader('Guardando')
      try {
        const request = {
          IdParteRoleDoctor: Number.parseInt(this.$route.query.idParteRoleDoctor),
          IdHora: Number.parseInt(this.$route.query.idHorario),
          Fecha: this.reservation.fecha,
          Patient: this.reservation.patient
        }
        await this.$axios.post('/api/schedule', request)
      } catch {
        this.$vToastify.error('Sucedio un error al reservar')
      } finally {
        this.$vToastify.stopLoader(_proccessId)
        this.back()
      }
    },
    async search () {
      if (this.reservation.patient.mail.length > 0) {
        const _proccessId = this.$vToastify.loader('Buscando correo electronico')
        try {
          const response = await this.$axios.get(`/api/persons/patients/${this.reservation.patient.mail}`)
          this.reservation.patient.idParteRole = response.data.idParteRole
          this.reservation.patient.nombre = response.data.nombre
          this.reservation.patient.apellidoPaterno = response.data.apellidoPaterno
          this.reservation.patient.apellidoMaterno = response.data.apellidoMaterno
        } catch (e) {
          if (e.response.status == 404) {
            this.$vToastify.info('Correo Electronico no encontrado')
          }
        } finally {
          this.searched = true
          this.readonly = true
          this.$vToastify.stopLoader(_proccessId)
        }
      } else {
        this.$vToastify.info('Ingresa el correo electronico')
      }
    },
    add() {
      if (this.reservation.patient.idParteRole <= 0 && this.searched) {
        this.readonly = false
      }
    },
    back() {
      this.$router.back()
    }
  }
}
</script>
<style scoped>
.input {
  @apply h-10 my-auto p-2 rounded-md;
}
.action-button {
  @apply h-10 w-16 text-white my-auto rounded-md shadow-xl hover:shadow-inner hover:bg-blue-600 bg-blue-500;
}
.form-button {
  @apply h-10 flex flex-row justify-start my-auto space-x-1 text-white font-semibold px-2 rounded-md shadow-md hover:shadow-inner;
}
</style>
