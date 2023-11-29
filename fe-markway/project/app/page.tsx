"use client"
import { useRouter } from 'next/navigation';
import '../public/css/style.css';
import { Header } from '@/components';


export default function Home() {
  const router = useRouter();

  const goToShipments = () => {
    router.push('/shipments');
  }

  return (
    <main className='main-container'>
      <div id="home-container">
        <div className='description-container'>
          <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.</span>
          <button onClick={goToShipments}>
            Pregled tura
          </button>
        </div>
        <div className='img-container'>
          <img src={"./images/route.svg"} />
        </div>
      </div>
    </main>
  )
}
