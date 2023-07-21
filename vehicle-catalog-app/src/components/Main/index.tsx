import { PropsWithChildren } from "react";
import { MainContainer } from "./styles";

export default function Main({ children }: PropsWithChildren) {
  return (
    <MainContainer>
      {children}
    </MainContainer>
  )
}