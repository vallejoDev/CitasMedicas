export default (context, inject) => {
  const formatCurrency = function (number) {
    try {
      return number != undefined
        ? (number).toLocaleString('es-MX', {
            style: 'currency',
            currency: 'MXN'
          })
        : ''
    } catch (e) {
      return ''
    }
  }
  inject('formatCurrency', formatCurrency)
}
