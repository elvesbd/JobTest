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
  color: '$gray500'
})