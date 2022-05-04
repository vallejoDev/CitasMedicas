<template>
  <form class="bg-gray-100 h-16 flex justify-around space-x-2 px-2" @submit.prevent="update">
    <label class="my-auto">
      Fecha:
    </label>
    <input
      v-model="fecha"
      class="h-8 my-auto w-full rounded-sm"
      type="date"
      required
      @change="change"
    >
    <button
      class="h-8 flex flex-row my-auto space-x-1 bg-blue-500 hover:bg-blue-600 text-white font-semibold px-2 rounded-md shadow-md hover:shadow-inner w-auto"
    >
      <svg xmlns="http://www.w3.org/2000/svg" class="my-auto h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
        <path fill-rule="evenodd" d="M4 2a1 1 0 011 1v2.101a7.002 7.002 0 0111.601 2.566 1 1 0 11-1.885.666A5.002 5.002 0 005.999 7H9a1 1 0 010 2H4a1 1 0 01-1-1V3a1 1 0 011-1zm.008 9.057a1 1 0 011.276.61A5.002 5.002 0 0014.001 13H11a1 1 0 110-2h5a1 1 0 011 1v5a1 1 0 11-2 0v-2.101a7.002 7.002 0 01-11.601-2.566 1 1 0 01.61-1.276z" clip-rule="evenodd" />
      </svg>
      <span class="my-auto">
        Actualizar
      </span>
    </button>
  </form>
</template>
<script>
export default {
  data() {
    return {
      fecha: new Date().toLocaleDateString()
    }
  },
  methods: {
    update() {
      this.$emit('onSearch', this.fecha)
    },
    change() {
      this.$emit('onChange')
    }
  }
}
</script>
