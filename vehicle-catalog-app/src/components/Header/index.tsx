import Image from 'next/image'
import logoImg from '../../assets/logo.svg'
import { ContainerHeader } from "./styles"

interface HeaderProps {
  name: string;
}

export default function Header({ name }: HeaderProps) {
  return (
    <ContainerHeader>
      <Image src={logoImg} alt="Logo Image" />
      <div>{name}</div>
    </ContainerHeader>
  )
}
