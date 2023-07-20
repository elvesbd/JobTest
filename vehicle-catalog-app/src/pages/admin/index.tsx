import { hasCookie } from 'cookies-next';
import { GetServerSideProps } from 'next';


export default function Admin() {
  return (
    <h1>admin</h1>
  )
}

export const getServerSideProps: GetServerSideProps = async ({ req, res }) => {
  const token = hasCookie('vehicle_catalog_api', { req, res });
  if (!token) {
    return {
      redirect: {
        permanent: false,
        destination: '/login'
      }
    };
  }

  return {
    props: {}
  };
};






