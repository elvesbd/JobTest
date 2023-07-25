import { useEffect, useMemo, useState } from 'react';
import { GetServerSideProps } from 'next';
import { useRouter } from 'next/router';
import { deleteCookie, getCookie } from 'cookies-next';

import Header from '../../components/Header';
import Vehicle from '../../components/Vehicle';
import car2 from '../../assets/car2.jpg'
import api from '../../services/api';
import ConsoleAdmin from '../../components/ConsoleAdmin';
import { AdminContainer, MainAdminContainer } from '../../styles/pages/admin';
import { TokenProps, VehicleProps, VehicleData } from './interfaces';
import { formatCurrency } from '../../utils/format-currency';

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
                  price={formatCurrency(vehicle.priceInCents)}
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






