import Image from "next/image";
import { RegisterContainer, RegisterFormContainer } from "../../styles/pages/register";
import RegisterCard from "../../components/RegisterCard";
import bannerImage from '../../assets/banner.jpg'
import Input from "../../components/InputCard";
import Button from "../../components/Button";
import Link from "next/link";

export default function Register() {
  return (
    <RegisterContainer>
      <Image src={bannerImage} alt="Banner" />
     
      <RegisterFormContainer>
        <RegisterCard title="Realizar cadastro">
          <form action="">
            <Input type="Text" placeholder="Nome"/>
            <Input type="email" placeholder="E-mail"/>
            <Input type="number" placeholder="Telefone com DDD"/>
            <Input type="Text" placeholder="Senha"/>
            <Button>Cadastrar</Button>
            <Link href="/login">Já possui conta? Clique aqui</Link>
          </form>
        </RegisterCard>
      </RegisterFormContainer>
    </RegisterContainer>
  )
}