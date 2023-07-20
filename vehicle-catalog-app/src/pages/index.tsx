import Header from "../components/Header";
import { HomeContainer } from "../styles/pages/home";
import Vehicle from "../components/Vehicle";
import car1 from '../assets/car1.jpg'
import car2 from '../assets/car2.jpg'
import car3 from '../assets/car3.jpg'
import SearchInput from "../components/SearchInput";

export default function Home() {
  return (
    <>
      <Header name="Cadastre-se"/>
      <SearchInput />
      <HomeContainer>
        <Vehicle
          image={car1}
          name="Car 1"
          brand="Marca"
          model="Modelo"
        />

        <Vehicle
          image={car2}
          name="Car 1"
          brand="Marca"
          model="Modelo"
        />

        <Vehicle
          image={car3}
          name="Car 1"
          brand="Marca"
          model="Modelo"
        />

        <Vehicle
          image={car3}
          name="Car 1"
          brand="Marca"
          model="Modelo"
        />

        <Vehicle
          image={car3}
          name="Car 1"
          brand="Marca"
          model="Modelo"
        />
      </HomeContainer>
    </>
  )
}
