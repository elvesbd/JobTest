import Image, { StaticImageData } from "next/image";
import { ContainerVehicle } from "./styles";

interface VehicleProps {
  image: StaticImageData;
  name: string;
  brand: string;
  model: string;
}

export default function Vehicle({ image, name, brand, model }: VehicleProps) {
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