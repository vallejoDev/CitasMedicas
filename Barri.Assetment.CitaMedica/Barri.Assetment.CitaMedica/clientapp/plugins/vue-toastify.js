import Vue from 'vue'
import VueToastify from 'vue-toastify'

Vue.use(VueToastify, {
  position: 'top-right',
  theme: 'light',
  canPause: true,
  close: true,
  duration: -1
})
