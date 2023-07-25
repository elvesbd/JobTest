import { styled } from "../../styles";

export const ContainerVehicle = styled('a', {
  minHeight: 280,
  backgroundColor: '$white',
  borderRadius: 8,
  cursor: 'pointer',
  boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',

  img: {
    objectFit: 'cover'
  },

  footer: {
    fontSize: '$md',
    padding: '0.5rem',
    display: 'flex',
    flexDirection: 'column',
    gap: '0.5rem',

    span: {
      color: '$gray400',
      fontSize: '$sm',
    },

    'span:last-child': {
      fontSize: '20px',
      fontWeight: 'bold',
      color: '$green500'
    }
  }
})