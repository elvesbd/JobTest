export interface VehicleProps {
  id: string;
  name: string;
  brand: string;
  image: string;
  model: string;
  priceInCents: number;
}

export interface VehicleData {
  data: VehicleProps[];
}

export interface TokenProps {
  token: string
}
