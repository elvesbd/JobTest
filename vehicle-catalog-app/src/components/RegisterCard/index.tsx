import { RegisterCardContainer } from "./styles";

export default function RegisterCard({ title, children }) {
  return (
    <RegisterCardContainer>
      <h2>{title}</h2>
      {children}
    </RegisterCardContainer>
  )
}