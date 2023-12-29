'use client';
import RegisterForm from '@/components/RegisterForm';
import ValidationPatterns from '@/constants/ValidationPatterns';
import ToastContext from '@/context/ToastContext';
import { register } from '@/services/UserService';
import { useContext } from 'react';
import { useForm } from 'react-hook-form';
import { ToastContainer, toast } from 'react-toastify';

export default function Register() {
  const form = useForm();
  const {
    handleSubmit,
    formState: { errors },
  } = form;

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
    register(data).then((response) => {
      setToastOpened(true, true, 'Uspešno registrovana firma.');
    });
  };

  return (
    <div id='register-container'>
      <h2>Registruj firmu</h2>
      <RegisterForm
        form={form}
        formRules={formRules}
        onSubmit={handleSubmit(onSubmit)}
        errors={errors}
      />
    </div>
  );
}
