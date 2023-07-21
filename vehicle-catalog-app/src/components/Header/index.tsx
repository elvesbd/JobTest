import Image from 'next/image'
import logoImg from '../../assets/logo.svg'
import { ContainerHeader } from "./styles"
import Link from 'next/link';

interface HeaderProps {
  name: string;
  redirect: string;
}

export default function Header({ name, redirect }: HeaderProps) {
  return (
    <ContainerHeader>
      <Image src={logoImg} alt="Logo Image" />
      <Link href={redirect}>
        <div>{name}</div>
      </Link>
    </ContainerHeader>
  )
}
