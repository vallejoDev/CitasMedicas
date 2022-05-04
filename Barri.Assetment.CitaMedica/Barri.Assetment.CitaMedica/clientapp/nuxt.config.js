import path from 'path'
import fs from 'fs'

process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0'
export default {
  head: {
    title: 'Citas Medicas',
    htmlAttrs: {
      lang: 'es-MX'
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' },
      { name: 'format-detection', content: 'telephone=no' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },
  router: {
    prefetchLinks: true,
    middleware: ['auth']
  },
  server: {
    https: {
      key: fs.readFileSync(path.resolve(__dirname, 'server.key')),
      cert: fs.readFileSync(path.resolve(__dirname, 'server.crt'))
    }
  },
  auth: {
    plugins: [{ src: '~/plugins/axios', ssr: true }],
    strategies: {
      facebook: {
        endpoints: {
          userInfo: 'https://graph.facebook.com/v6.0/me?fields=id,name,picture{url}'
        },
        clientId: '714489556636564',
        scope: ['public_profile', 'email']
      }
    }
  },
  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [
    '~assets/css/tailwind.css'
  ],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [
    { src: '@/plugins/vue-toastify.js', mode: 'client' },
    { src: '~/plugins/vuelidate.js', mode: 'client' },
    { src: '~plugins/currency.js' }
  ],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: [
    {
      path: '~/components', // will get any components nested in let's say /components/test too
      pathPrefix: false
    }
  ],

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/eslint
    '@nuxtjs/eslint-module',
    // https://go.nuxtjs.dev/tailwindcss
    '@nuxtjs/tailwindcss'
  ],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/axios
    '@nuxtjs/axios',
    '@nuxtjs/proxy',
    '@nuxtjs/auth-next'
  ],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    // Workaround to avoid enforcing hard-coded localhost:3000: https://github.com/nuxt-community/axios-module/issues/308
    proxy: true,
    https: true
  },
  proxy: {
    '/api/': {
      target: 'http://localhost:64187/',
      // target: process.env.NODE_ENV === 'production' ? 'http://localhost:8090/api/' : 'http://13.67.134.23:8090/api/',
      pathRewrite: { '^/api/': '' },
      changeOrigin: true
    },
    '/user/': {
      target: 'https://seguridad.loteria.traffics.mx/user_admin/',
      // target: process.env.NODE_ENV === 'production' ? 'http://localhost:8080/user/' : 'https://seguridad.loteria.traffics.mx/user/',
      pathRewrite: { '^/user/': '' },
      changeOrigin: true
    }

  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    extend(config, ctx) {
      config.resolve.alias.vue = 'vue/dist/vue.common'
    },
    terser: {
      terserOptions: {
        compress: {
          drop_console: true
        }
      }
    }
  }
}
