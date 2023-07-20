import { styled } from "../../styles";

export const ContainerSearchInput = styled('div', {
  backgroundColor: '$green600',
  width: '100%',
  minHeight: '4rem',
  borderRadius: 3,

  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',

  input: {
    width: 850,
    height: 48,
    paddingLeft: 4,
    borderRadius: 8,
    outline: 'none',
    border: 'none',
    fontSize: '$m',
    color: '$gray500',
  }
})