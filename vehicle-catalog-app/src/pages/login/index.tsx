import Image from "next/image";
import Link from "next/link";
import LoginCard from "../../components/LoginCard";
import bannerImage from '../../assets/banner.jpg';
import Input from "../../components/InputCard";
import Button from "../../components/Button";
import { LoginContainer, LoginFormContainer } from "../../styles/pages/login";


export default function Login() {
  return (
    <LoginContainer>
     <Image src={bannerImage} alt="Banner" />
     
     <LoginFormContainer>
       <LoginCard title="Realizar login">
         <form action="">
           <Input type="email" placeholder="E-mail"/>
           <Input type="password" placeholder="Senha"/>
           <Button>Login</Button>
           <Link href="/register">Ainda não possui conta? Clique aqui</Link>
         </form>
       </LoginCard>
     </LoginFormContainer>
    </LoginContainer>
  )
}