import { styled } from "../../styles";

export const ConsoleAdminContainer = styled('div', {
  display: 'flex',
  flexDirection: 'column',
  margin: '2rem 0 0 1rem',

  h1: {
    fontSize: '$xl',
    color: '$gray800'
  }
})

export const ButtonContainer = styled('div', {
  display: 'flex',
  flexDirection: 'column',
  alignItems: 'flex-start',
  gap: '1rem',
  marginTop: '1rem',
 
  button: {
    background: 'none',
    border: 'none',
    cursor: 'pointer',
    color: '$green600',
    fontSize: '$sm',
    transition: 'ease-in 0.1s',
  
    '&:hover': {
      color: '$gray400'
    }
  }
})