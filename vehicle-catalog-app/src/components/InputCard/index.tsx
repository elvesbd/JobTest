import { InputHTMLAttributes } from "react";
import { InputCard } from "./styles";

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{}

export default function Input(props: InputProps) {
  return (
    <InputCard type="text" {...props} />
  )
}