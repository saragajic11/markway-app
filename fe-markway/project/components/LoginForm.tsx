import { FormProvider } from 'react-hook-form';
import TextFieldControl from './controls/inputs/TextFieldControl';
import { Button } from '@mui/material';

const LoginForm = ({
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
      <form id='login-form' className='login-form' onSubmit={onSubmit}>
        <TextFieldControl
          name='username'
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
          helperText={errors.password && 'Molimo unesite validnu šifru.'}
        />

        <Button type='submit' onSubmit={onSubmit}>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default LoginForm;
