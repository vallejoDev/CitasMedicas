<template>
  <simple-layout>
    <login-component />
  </simple-layout>
</template>
<script>
import SimpleLayout from '@/layouts/simple-layout.vue'
import LoginComponent from '@/components/login-component.vue'
export default {
  components: {
    SimpleLayout,
    LoginComponent
  },
  auth: 'guest'
}
</script>
