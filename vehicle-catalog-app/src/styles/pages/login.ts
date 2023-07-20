import { styled } from "..";

export const LoginContainer = styled('div', {
  display: 'flex',
  alignItems: 'center',
  backgroundColor: '$white200',
  minHeight: '100vh',


  img: {
    flex: 1,
    width: 600,
    height: '100vh'
  },
})

export const LoginFormContainer = styled('div', {
  flex: 1,
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  width: 400,

  form: {
    display: 'flex',
    flexDirection: 'column',
    gap: 10,
  }
})