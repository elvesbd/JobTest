import { useEffect, useState } from "react";
import { GetServerSideProps } from "next";
import { useRouter } from "next/router";
import { deleteCookie, getCookie } from "cookies-next";

import SearchInput from "../components/SearchInput";
import Header from "../components/Header";
import Vehicle from "../components/Vehicle";
import Main from "../components/Main";
import api from "../services/api";
import car1 from '../assets/car1.jpg'
import { formatCurrency } from "../utils/format-currency";

interface VehicleProps {
  id: string;
  name: string;
  brand: string;
  image: string;
  model: string;
  priceInCents: number;
}

interface VehicleData {
  data: VehicleProps[];
}

export default function Home() {
  const [vehicles, setVehicles] = useState<VehicleProps[]>([])
  const router = useRouter()

  const handleDeleteCookie = () => {
    deleteCookie('vehicle_catalog_api')
    router.push('/')
  }
  const token = getCookie('vehicle_catalog_api')
 
  useEffect(() => {
    const getVehiclesData = async () => {
      try {
        const response = await api.get<VehicleData>('vehicles');
        const { data } = response.data;
        setVehicles(data)
        if (response.status !== 200) throw new Error()
  
      } catch (error) {
        alert(error.response?.data.errors)
      }
    }
    getVehiclesData()
  }, [])

  const handleRegister = () => {
    router.push('/register')
  }

  const handleLogin = () => {
    router.push('/login')
  }

  const handleAdmin = () => {
    router.push('/admin')
  }
  
  return (
    <>
      <Header>
      {token ? (
        <div>
          <button onClick={handleAdmin}>Admin</button>
          <button onClick={handleDeleteCookie}>Sair</button>
        </div>
      ) : (
        <div>
          <button onClick={handleRegister}>Cadastre-se</button>
          <button onClick={handleLogin}>Login</button>
        </div>
      )}
      </Header>
      <SearchInput />
      <Main>
        { vehicles.map((vehicle) => (
          <Vehicle
          key={vehicle.id}
          image={car1}
          name={vehicle.name}
          brand={vehicle.brand}
          model={vehicle.model}
          price={formatCurrency(vehicle.priceInCents)}
        />
        )) }
      </Main>
    </>
  )
}

export const getServerSideProps: GetServerSideProps = async ({ req, res }) => {
  const token = getCookie('vehicle_catalog_api', { req, res });
  if (!token) {
    return {
      props: {}
    };
  }

  return {
    props: {
      token
    }
  };
};