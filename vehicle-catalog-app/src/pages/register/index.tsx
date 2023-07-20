import Image from "next/image";
import Link from "next/link";
import { useState } from "react";
import { useRouter } from 'next/router';

import api from "../../services/api";
import RegisterCard from "../../components/RegisterCard";
import Input from "../../components/InputCard";
import Button from "../../components/Button";
import bannerImage from '../../assets/banner.jpg'
import { UserProps, FormEventProps, EventProps } from "./interfaces";
import { RegisterContainer, RegisterFormContainer } from "../../styles/pages/register";

export default function Register() {
  const [user, setUser] = useState<UserProps>({
    name: '',
    email: '',
    cellPhone: '',
    password: ''
  })
  const router = useRouter();


  const handleSubmit = async (e: FormEventProps) => {
    e.preventDefault()
   
    try {
      const response = await api.post('users', user);
      if (response.status !== 201) throw new Error()
      setUser({
        name: '',
        email: '',
        cellPhone: '',
        password: ''
      })
      router.push('/login');
    } catch (error) {
       alert(error.response.data.errors);
    }
  }

  const handleFormData = (e: EventProps, name: string) => {
    setUser((prevState) => ({
      ...prevState,
      [name]: e.target.value
    }));
  };

  return (
    <RegisterContainer>
      <Image src={bannerImage} alt="Banner" />
     
      <RegisterFormContainer>
        <RegisterCard title="Realizar cadastro">
          <form onSubmit={handleSubmit} action="">
            <Input
              type="text"
              placeholder="Nome"
              required
              value={user.name}
              onChange={(e) => {handleFormData(e, 'name')}}
            />
            <Input
              type="email"
              placeholder="E-mail"
              required
              value={user.email}
              onChange={(e) => {handleFormData(e, 'email')}}
            />
            <Input
              type="number"
              placeholder="Telefone com DDD"
              required
              value={user.cellPhone}
              onChange={(e) => {handleFormData(e, 'cellPhone')}}
            />
            <Input
              type="text"
              placeholder="Senha"
              required
              value={user.password}
              onChange={(e) => {handleFormData(e, 'password')}}
            />
            <Button>Cadastrar</Button>
            <Link href="/login">Já possui conta? Clique aqui</Link>
          </form>
        </RegisterCard>
      </RegisterFormContainer>
    </RegisterContainer>
  )
}