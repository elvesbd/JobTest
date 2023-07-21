import { styled } from "..";

export const AdminContainer = styled('div', {
  display: 'flex',
  flexDirection: 'column',

  div: {
    display: 'flex',
  }
})

export const MainAdminContainer = styled('main', {
  display: 'flex',
  flexWrap: 'wrap',
  alignItems: 'flex-start',
  gap: '1rem',

  padding: '2rem',
  width: '100%',
  //maxWidth: 1260,
  margin: '0 auto'
})