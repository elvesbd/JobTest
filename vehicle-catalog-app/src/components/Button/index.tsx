import { ButtonHTMLAttributes } from "react";
import { ButtonCard } from "./styles";

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement>{}

export default function Button({ children, ...props }: ButtonProps) {
  return (
    <ButtonCard {...props}>
      {children}
    </ButtonCard>
  )
}