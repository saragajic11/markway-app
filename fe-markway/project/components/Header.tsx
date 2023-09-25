import Image from 'next/image';
import React from 'react';

const Header = () => {
    return (
        <div id='header-container'>
            <div className='logo-container'>
                <img alt='markway-logo' className='logo' src={"/images/logo.png"} />
            </div>
            <div className='option-container'>
                <span className='sign-in'>Prijavi se</span>
                <span>Registruj se</span>
            </div>
        </div>
    )
}

export default Header;