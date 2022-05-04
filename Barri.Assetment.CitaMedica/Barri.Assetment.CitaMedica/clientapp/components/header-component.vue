<template>
  <header class="flex flex-col bg-blue-500 shadow-md fixed w-full">
    <div class=" flex flex-row justify-between mx-4">
      <div class="flex">
        <span class="my-auto font-bold text-2xl text-white">Citas Medicas</span>
      </div>
      <nav class="h-16 flex">
        <NuxtLink
          v-for="(item, index) in endpoints"
          :key="index"
          class="routerLink"
          :to="item.url"
        >
          <span class="my-auto">
            {{ item.name }}
          </span>
        </NuxtLink>
      </nav>
      <div v-show="$auth.loggedIn" class="flex flex-row space-x-2">
        <img :src="$auth.loggedIn ? $auth.user.picture.data.url : ''" class="my-auto w-14 h-14 border rounded-full object-contain">
        <span class="my-auto font-semibold text-lg text-white">{{ $auth.loggedIn ? $auth.user.name : '' }}</span>
        <button class="my-auto text-sm text-white" @click="$auth.logout()">
          Cerrar Sesión
        </button>
      </div>
    </div>
  </header>
</template>
<script>
export default {
  data() {
    return {
      endpoints: [
        {
          url: '/doctors',
          name: 'Doctores'
        }, {
          url: '/about',
          name: 'Acerca de'
        }
      ]
    }
  }
}
</script>
<style>
.routerLink {
  @apply text-center text-lg border-r-2 h-full px-4 border-blue-600 text-white flex content-center
}
a.nuxt-link-active {
  font-weight: bold;
}
</style>
