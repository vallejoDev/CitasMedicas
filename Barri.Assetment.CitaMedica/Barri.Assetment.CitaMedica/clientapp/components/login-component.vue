<template>
  <div class="w-64 h-96 mx-auto mt-16">
    <form class="h-full w-full flex flex-col justify-between border shadow-md" @submit.prevent="$auth.loginWith('facebook')">
      <h1 class="text-center font-bold py-4 text-2xl border-b bg-gray-50">
        Iniciar Sesión
      </h1>
      <div class="w-32 h-32 mx-auto rounded-full bg-gray-200 text-gray-600 border-solid border-indigo-500 shadow-md">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-28 w-28 mx-auto my-2" viewBox="0 0 20 20" fill="currentColor">
          <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM7 9a1 1 0 100-2 1 1 0 000 2zm7-1a1 1 0 11-2 0 1 1 0 012 0zm-.464 5.535a1 1 0 10-1.415-1.414 3 3 0 01-4.242 0 1 1 0 00-1.415 1.414 5 5 0 007.072 0z" clip-rule="evenodd" />
        </svg>
      </div>
      <button class="h-12 bg-blue-500 m-2 space-x-2 flex flex-row text-white shadow-lg rounded-sm hover:opacity-90" type="submit">
        <div class="w-12 h-full bg-blue-600 font-sans font-bold pt-2 text-3xl">
          f
        </div>
        <span class="my-auto text-center">Iniciar con Facebook</span>
      </button>
    </form>
  </div>
</template>
<script>
export default {
  ssr: true
}
</script>

<style>
</style>
