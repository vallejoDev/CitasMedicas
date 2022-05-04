<template>
  <simple-layout>
    <div class="w-[30rem] mx-auto mt-10">
      <div class="bg-blue-500 h-10 flex content-center">
        <span class="mx-auto my-auto text-center text-white font-bold">
          Agenda del doctor: {{ name }}
        </span>
      </div>
      <agenda-search-component @onSearch="search" @onChange="change" />
      <div>
        <ul>
          <li
            v-for="(horario) in horarios"
            :key="horario.idHorario"
            class="h-12 px-2 flex justify-between w-full even:bg-gray-50 odd:bg-gray-300 even:text-gray-500 odd:text-white"
          >
            <span class="my-auto font-semibold text-xl">
              {{ `${horario.hora}:00` }}
            </span>
            <span v-if="searched" class="my-auto font-semibold text-base text-left w-full ml-4">
              {{ find(horario.idHorario) }}
            </span>
            <NuxtLink
              v-show="searched && !any(horario.idHorario)"
              :to="{path: '/schedule/booking/', query: {idParteRoleDoctor, idHorario: horario.idHorario, horario: `${horario.hora}:00`, fecha} }"
              class="bg-green-500 hover:bg-green-600 hover:shadow-inner text-white h-8 w-auto my-auto px-4 pt-1 rounded-md shadow-md"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="m-auto h-6 w-6"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
                stroke-width="2"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"
                />
              </svg>
            </NuxtLink>
          </li>
        </ul>
      </div>
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
      name: 'Doctor house',
      fecha: '',
      horarios: [],
      reservations: [],
      searched: false,
      idParteRoleDoctor: 0
    }
  },
  async fetch() {
    try {
      this.idParteRoleDoctor = this.$route.params.edit
      const responseDoctor = await this.$axios.get(`/api/persons/doctors/${this.idParteRoleDoctor}`)
      const responseHorarios = await this.$axios.get('/api/schedule/Horarios')
      const doctor = responseDoctor.data
      this.name = `${doctor.nombre} ${doctor.apellidoPaterno} ${doctor.apellidoMaterno ? doctor.apellidoMaterno : ''}`.trim()
      this.horarios = responseHorarios.data
    } catch (e) {
      console.log(e)
    }
  },
  methods: {
    any(idHorario) {
      return this.reservations.filter(_ => _.idHorario == idHorario).length > 0
    },
    find(idHorario) {
      const reservation = this.reservations.find(_ => _.idHorario == idHorario)
      let formatedValue = 'Disponible'
      if (reservation) {
        formatedValue = `${reservation.mail} | ${reservation.nombre} ${reservation.apellidoPaterno} ${reservation.apellidoMaterno ? reservation.apellidoMaterno : ''}`.trim()
      }
      return formatedValue
    },
    async search (fecha) {
      const _proccessId = this.$vToastify.loader('Buscando')
      try {
        this.fecha = fecha
        const request = {
          fecha: this.fecha,
          idParteRole: this.idParteRoleDoctor
        }
        const response = await this.$axios.get('/api/schedule/filter', { params: request })
        this.reservations = response.data
        this.searched = true
      } catch (e) {
        console.log(e)
      } finally {
        this.$vToastify.stopLoader(_proccessId)
      }
    },
    change() {
      this.searched = false
      this.reservations = []
    }
  }
}
</script>
