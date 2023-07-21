import { useEffect, useState } from "react";
import SearchInput from "../components/SearchInput";
import Header from "../components/Header";
import Vehicle from "../components/Vehicle";
import api from "../services/api";
import car1 from '../assets/car1.jpg'
import car2 from '../assets/car2.jpg'
import car3 from '../assets/car3.jpg'
import Main from "../components/Main";
import { deleteCookie, getCookie } from "cookies-next";
import { GetServerSideProps } from "next";
import { useRouter } from "next/router";

interface VehicleProps {
  id: string;
  name: string;
  brand: string;
  image: string;
  model: string;
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
        {/* { vehicles.map((vehicle) => (
          <Vehicle
          key={vehicle.id}
          image={car1}
          name={vehicle.name}
          brand={vehicle.brand}
          model={vehicle.model}
        />
        )) }
        <Vehicle
          key=""
          image={car1}
          name=""
          brand=""
          model=""
        />
        <Vehicle
          key=""
          image={car2}
          name=""
          brand=""
          model=""
        />
        <Vehicle
          key=""
          image={car3}
          name=""
          brand=""
          model=""
        /> */}
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