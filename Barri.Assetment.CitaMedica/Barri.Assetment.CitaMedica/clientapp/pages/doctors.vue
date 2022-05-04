<template>
  <simple-layout>
    <div class="w-96 mx-auto mt-10">
      <div class="bg-blue-500 h-10 flex content-center">
        <span class="mx-auto my-auto text-center text-white font-bold">
          Listado de doctores
        </span>
      </div>
      <div>
        <ul>
          <doctor-item-component
            v-for="(doctor, index) in doctors"
            :key="index"
            :doctor="doctor"
          />
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
      doctors: []
    }
  },
  async fetch() {
    try {
      const response = await this.$axios.get('/api/persons/doctors')
      this.doctors = response.data
    } catch (e) {
      console.log(e)
    }
  },
  auth: true
}
</script>
