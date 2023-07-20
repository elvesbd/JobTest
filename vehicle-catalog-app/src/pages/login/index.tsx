import Image from "next/image";
import LoginCard from "../../components/LoginCard";
import { LoginContainer, LoginFormContainer } from "../../styles/pages/login";
import bannerImage from '../../assets/banner.jpg'
import Input from "../../components/InputCard";
import Button from "../../components/Button";


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
         </form>
       </LoginCard>
     </LoginFormContainer>
    </LoginContainer>
  )
}