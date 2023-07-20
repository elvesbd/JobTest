import { createStitches } from '@stitches/react'

export const {
  config,
  styled,
  globalCss,
  keyframes,
  getCssText,
  theme,
  createTheme
} = createStitches({
  theme: {
    colors: {
      white: '#FFF',
      white200: '#F5F5F5',

      gray900: '#121214',
      gray800: '#202024',
      gray500: '#333333',
      gray400: '#898989',
      gray300: '#c4c4cc',
      gray200: '#e7e7e7',
      gray100: '#e1e1e6',

      green600: '#087F5B',
      green500: '#00875f',
      green300: '#00b37e',
    },
    fontSizes: {
      s: '0.8rem',
      sm: '1rem',
      md: '1.125rem',
      lg: '1.25rem',
      xl: '1.5rem',
      '2xl': '2rem'
    }
  }
})