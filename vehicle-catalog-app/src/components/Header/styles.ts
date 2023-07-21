import { styled } from "../../styles";

export const ContainerHeader = styled('header', {
  display: 'flex',
  flexDirection: 'row',
  alignItems: 'center',
  justifyContent: 'space-between',
  
  padding: '2rem 0',
  width: '100%',
  maxWidth: 1260,
  margin: '0 auto',

  button: {
    background: 'none',
    border: 'none',
    textDecoration: 'none',
    cursor: 'pointer',
    color: '$gray500',
    transition: 'ease-in 0.1s',

    '&:hover': {
      color: '$gray400'
    }
  },

  div: {
    display: 'flex',
    gap: '1rem',
  }
})

  