import { useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { useRouter } from 'next/router';
import { setCookie } from 'cookies-next';

import LoginCard from "../../components/LoginCard";
import Input from "../../components/InputCard";
import Button from "../../components/Button";
import bannerImage from '../../assets/banner.jpg';
import { LoginContainer, LoginFormContainer } from "../../styles/pages/login";
import api from "../../services/api";

interface LoginProps {
  email: string;
  password: string;
}

interface LoginResponseProps {
  data: string;
}

interface ErrorsProps {
  errors: string[];
}

type EventProps = React.ChangeEvent<HTMLInputElement>
type FormEventProps =  React.FormEvent<HTMLFormElement>

export default function Login() {
  const [loginData, setLoginData] = useState<LoginProps>({email: '', password: ''})
  const router = useRouter();

   const handleSubmit = async (e: FormEventProps) => {
    e.preventDefault()
   
    try {
      const response = await api.post<LoginResponseProps>('login', loginData);
      const { data: { data: accessToken } } = response;
      if (response.status !== 200) throw new Error()

      setCookie('vehicle_catalog_api', accessToken)
      router.push('/admin');
    } catch (error) {
      alert(error.response.data.errors)
    }
  }

  const handleFormData = (e: EventProps, name: string) => {
    setLoginData((prevState) => ({
      ...prevState,
      [name]: e.target.value
    }));
  };

  return (
    <LoginContainer>
     <Image src={bannerImage} alt="Banner" />
     
     <LoginFormContainer>
       <LoginCard title="Realizar login">
         <form onSubmit={handleSubmit} action="">
           <Input
            type="email"
            placeholder="E-mail"
            required
            value={loginData.email}
            onChange={(e) => {handleFormData(e, 'email')}}
          />
           <Input
            type="password"
            placeholder="Senha"
            required
            value={loginData.password}
            onChange={(e) => {handleFormData(e, 'password')}}  
          />
            <Button>Login</Button>
            <Link href="/register">Ainda não possui conta? Clique aqui</Link>
         </form>
       </LoginCard>
     </LoginFormContainer>
    </LoginContainer>
  )
}