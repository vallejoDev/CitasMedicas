<template>
  <li
    class="h-12 px-2 flex justify-between w-full even:bg-gray-50 odd:bg-gray-300 even:text-gray-500 odd:text-white"
  >
    <span class="my-auto font-semibold text-xl">
      {{ `${doctor.nombre} ${doctor.apellidoPaterno} ${doctor.apellidoMaterno ? doctor.apellidoMaterno : ''}`.trim() }}
    </span>
    <NuxtLink
      :to="`/schedule/${doctor.idParteRole}`"
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
        <path stroke-linecap="round" stroke-linejoin="round" d="M10 21h7a2 2 0 002-2V9.414a1 1 0 00-.293-.707l-5.414-5.414A1 1 0 0012.586 3H7a2 2 0 00-2 2v11m0 5l4.879-4.879m0 0a3 3 0 104.243-4.242 3 3 0 00-4.243 4.242z" />
      </svg>
    </NuxtLink>
  </li>
</template>
<script>
export default {
  props: {
    doctor: {
      type: Object,
      default: () => {}
    }
  }
}
</script>
