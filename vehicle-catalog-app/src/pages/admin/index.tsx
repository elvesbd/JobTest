import { deleteCookie, getCookie, hasCookie } from 'cookies-next';
import { GetServerSideProps } from 'next';
import Header from '../../components/Header';
import { useEffect, useMemo, useState } from 'react';
import Vehicle from '../../components/Vehicle';
import car1 from '../../assets/car1.jpg'
import car2 from '../../assets/car2.jpg'
import car3 from '../../assets/car3.jpg'
import api from '../../services/api';
import Main from '../../components/Main';
import { useRouter } from 'next/router';
import { InputCard } from '../../components/InputCard/styles';
import SearchInput from '../../components/SearchInput';
import ConsoleAdmin from '../../components/ConsoleAdmin';
import { AdminContainer, MainAdminContainer } from '../../styles/pages/admin';

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

interface TokenProps {
  token: string
}


export default function Admin({ token }: TokenProps) {
  const [vehicles, setVehicles] = useState<VehicleProps[]>([])
  const router = useRouter()
  
  const handleDeleteCookie = () => {
    deleteCookie('vehicle_catalog_api')
    router.push('/')
  }

  const config = useMemo(() => {
    return {
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
  }, [token]);

    useEffect(() => {
      const getUserVehiclesData = async () => {
        try {
          const response = await api.get<VehicleData>('vehicles/user', config);
          const { data } = response.data;
          setVehicles(data)
          if (response.status !== 200) throw new Error()
    
        } catch (error) {
          alert(error.response?.data.errors)
        }
      }
      getUserVehiclesData()
    }, [config])

  return (
    <AdminContainer>
      <Header>
        <button onClick={handleDeleteCookie}>Sair</button>
      </Header>
        <div>
          <ConsoleAdmin />
          <MainAdminContainer>
            { vehicles.map((vehicle) => (
                <Vehicle
                  key={vehicle.id}
                  image={car2}
                  name={vehicle.name}
                  brand={vehicle.brand}
                  model={vehicle.model}
                />
              )) }
          </MainAdminContainer>
        </div>
    </AdminContainer>
  )
}

export const getServerSideProps: GetServerSideProps = async ({ req, res }) => {
  const token = getCookie('vehicle_catalog_api', { req, res });
  if (!token) {
    return {
      redirect: {
        permanent: false,
        destination: '/login'
      }
    };
  }

  return {
    props: {
      token
    }
  };
};






