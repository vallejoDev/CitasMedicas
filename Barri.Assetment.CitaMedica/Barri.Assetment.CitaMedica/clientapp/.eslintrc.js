module.exports = {
  root: true,
  env: {
    browser: true,
    node: true
  },
  parserOptions: {
    parser: '@babel/eslint-parser',
    requireConfigFile: false
  },
  extends: [
    '@nuxtjs',
    'plugin:nuxt/recommended'
  ],
  plugins: [
  ],
  // add your custom rules here
  rules: {
    eqeqeq: 'off',
    'no-new': 'off',
    'no-unused-expressions': 'off',
    'space-before-function-paren': 'off',
    'no-console': 'off',
    'no-return-assign': 'off',
    'vue/multi-word-component-names': 0
  }
}
