'use client';
import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import '../public/css/style.css';
import { Header } from '@/components';
import ToastContext from '@/context/ToastContext';
import { ToastContainer } from 'react-toastify';
import { useContext } from 'react';
import 'react-toastify/dist/ReactToastify.min.css';

const inter = Inter({ subsets: ['latin'] });

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const { isToastOpened, setToastOpened } = useContext(ToastContext);
  const value = {
    isToastOpened: isToastOpened,
    setToastOpened: setToastOpened,
  };
  return (
    <html lang='en'>
      <body>
        <ToastContainer
          position='bottom-left'
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          theme='light'
        />
        <Header />
        {children}
      </body>
    </html>
  );
}
