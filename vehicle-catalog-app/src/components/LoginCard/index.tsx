import { LoginCardContainer } from "./styles";

export default function LoginCard({ title, children }) {
  return (
    <LoginCardContainer>
      <h2>{title}</h2>
      {children}
    </LoginCardContainer>
  )
}