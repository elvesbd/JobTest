import { styled } from "../../styles";

export const CardContainer = styled('div', {
  backgroundColor: '$white',
  width: '400px',
  padding: 20,
  borderRadius: 10,
  boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',

  h2: {
    textAlign: 'center',
    padding: '1rem',
    fontSize: '$2xl',
    color: '$gray500'
  }
})