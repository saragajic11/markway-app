import { FormProvider } from 'react-hook-form';
import TextFieldControl from './controls/inputs/TextFieldControl';
import { Button } from '@mui/material';

const RegisterForm = ({
  onSubmit,
  form,
  formRules,
  errors,
}: {
  onSubmit: any;
  form: any;
  formRules: any;
  errors: any;
}) => {
  return (
    <FormProvider {...form}>
      <form id='register-form' className='register-form' onSubmit={onSubmit}>
        <TextFieldControl
          name='email'
          rules={formRules['email']}
          fullWidth
          margin='normal'
          label={'Email adresa'}
          error={Boolean(errors.email)}
          helperText={errors.email && 'Molimo unesite validnu email adresu'}
        />
        <TextFieldControl
          name='password'
          type='password'
          rules={formRules['password']}
          fullWidth
          margin='normal'
          label={'Lozinka'}
          error={Boolean(errors.password)}
          helperText={
            errors.password &&
            'Molimo unesite validnu šifru. Šifra mora sadržati minimum 8 karaktera i ispunjavati 3 od 4 uslova: veliko slovo, malo slovo, broj, i specijalni karakter (npr. !@#$%^&*)'
          }
        />

        <Button type='submit' onSubmit={onSubmit}>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default RegisterForm;
