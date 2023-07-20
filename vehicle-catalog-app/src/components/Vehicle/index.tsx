import Image from "next/image";
import { ContainerVehicle } from "./styles";

export default function Vehicle({ image, name, brand, model }) {
  return (
    <ContainerVehicle>
      <Image
        src={image}
        width={300}
        height={180}  
        alt="Image de um carro"
      />
      <footer>
        <strong>{name}</strong>
        <span>{brand}</span>
        <span>{model}</span>
      </footer>
    </ContainerVehicle>
  )
}