import { CardContainer } from "./styles";

export default function Card({ title, children }) {
  return (
    <CardContainer>
      <h2>{title}</h2>
      {children}
    </CardContainer>
  )
}