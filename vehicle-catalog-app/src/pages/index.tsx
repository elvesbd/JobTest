import { useEffect, useState } from "react";
import SearchInput from "../components/SearchInput";
import Header from "../components/Header";
import Vehicle from "../components/Vehicle";
import api from "../services/api";
import car1 from '../assets/car1.jpg'
import { HomeContainer } from "../styles/pages/home";

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
 
    useEffect(() => {
      const getVehiclesData = async () => {
        try {
          const response = await api.get<VehicleData>('vehicles');
          const { data } = response.data;
          setVehicles(data)
          if (response.status !== 200) throw new Error()
    
        } catch (error) {
          alert(error.response.data.errors)
        }
      }
      getVehiclesData()
    }, [])
  

  return (
    <>
      <Header name="Cadastre-se"/>
      <SearchInput />
      <HomeContainer>
        { vehicles.map((vehicle) => (
          <Vehicle
          key={vehicle.id}
          image={car1}
          name={vehicle.name}
          brand={vehicle.brand}
          model={vehicle.model}
        />
        )) }
      </HomeContainer>
    </>
  )
}