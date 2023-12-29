import Image from 'next/image';
import React from 'react';
import { useRouter } from 'next/navigation';

const Header = () => {
  const router = useRouter();
  const navigateToLogin = () => {
    router.push('/login');
  };

  const navigateToRegister = () => {
    router.push('/register');
  };

  const navigateToHome = () => {
    router.push('/');
  };
  return (
    <div id='header-container'>
      <div className='logo-container' onClick={navigateToHome}>
        <img alt='markway-logo' className='logo' src={'/images/logo.png'} />
      </div>
      <div className='option-container'>
        <span className='sign-in' onClick={navigateToLogin}>
          Prijavi se
        </span>
        <span onClick={navigateToRegister}>Registruj se</span>
      </div>
    </div>
  );
};

export default Header;
