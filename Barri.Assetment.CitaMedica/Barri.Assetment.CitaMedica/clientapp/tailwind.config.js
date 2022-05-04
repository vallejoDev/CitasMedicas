module.exports = {
  mode: 'jit',
  purge: [],
  theme: {
    extend: {
      shadow: {
        '2xl': '4px 4px 5px 2px rgba(150, 149, 149, 0.788)'
      },
      animation: {
        'spin-slow': 'spin 3s linear infinite',
        wiggle: 'wiggle 1s ease-in-out infinite'
      },
      keyframes: {
        wiggle: {
          '0%, 100%': { transform: 'rotate(-3deg)' },
          '50%': { transform: 'rotate(3deg)' }
        }
      }
    }
  },
  variants: {
    extend: { animation: ['hover', 'focus'] }
  }
}
