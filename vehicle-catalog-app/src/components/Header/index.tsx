import Image from 'next/image'
import logoImg from '../../assets/logo.svg'
import { ContainerHeader } from "./styles"
import Link from 'next/link';
import { PropsWithChildren } from 'react';

export default function Header({ children }: PropsWithChildren) {
  return (
    <ContainerHeader>
      <Link href="/">
        <Image src={logoImg} alt="Logo Image" />
      </Link>
      {children}
    </ContainerHeader>
  )
}
