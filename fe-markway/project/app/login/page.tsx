'use client';
import LoginForm from '@/components/LoginForm';
import RegisterForm from '@/components/RegisterForm';
import ValidationPatterns from '@/constants/ValidationPatterns';
import ToastContext from '@/context/ToastContext';
import { login } from '@/services/UserService';
import { useRouter } from 'next/navigation';
import { useContext } from 'react';
import { useForm } from 'react-hook-form';

export default function Login() {
  const form = useForm();
  const {
    handleSubmit,
    formState: { errors },
  } = form;

  const router = useRouter();
  const { setToastOpened } = useContext(ToastContext);

  const formRules = {
    email: {
      required: { value: true, message: 'Polje je obavezno' },
      pattern: {
        value: ValidationPatterns.EMAIL,
        message: 'Neispravan format',
      },
    },
    password: {
      required: { value: true, message: 'Polje je obavezno' },
      pattern: {
        value: ValidationPatterns.PASSWORD,
        message: 'Neispravan format',
      },
    },
  };

  const onSubmit = (data: any) => {
    const loginData = {
      ...data,
      grant_type: 'password',
      client_id: 'webapp',
    };
    login(loginData).then((response) => {
      window.localStorage.setItem('access_token', response?.data.access_token);
      setToastOpened(true, true, 'Uspešna prijava');
      router.push('/shipments');
    });
  };
  return (
    <div id='login-container'>
      <h2>Prijavi se</h2>
      <LoginForm
        form={form}
        formRules={formRules}
        errors={errors}
        onSubmit={handleSubmit(onSubmit)}
      />
    </div>
  );
}
