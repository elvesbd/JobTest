import { styled } from "../../styles";

export const ButtonCard = styled('button', {
  padding: '15px 30px',
  border: 0,
  backgroundColor: '$green600',
  borderRadius: 6,
  cursor: 'pointer',
  color: '$white',
  transition: 'ease-in 0.1s',

  '&:hover': {
    backgroundColor: '$green500'
  }
})