import { ButtonContainer, ConsoleAdminContainer } from "./styles";

export default function ConsoleAdmin() {
  return (
    <ConsoleAdminContainer>
      <h1>Console</h1>
      <ButtonContainer>
          <button>Cadastrar</button>
          <button>Editar</button>
          <button>Deletar</button>
      </ButtonContainer>
    </ConsoleAdminContainer>
  )
}