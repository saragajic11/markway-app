import { FormProvider } from 'react-hook-form';
import TextFieldControl from './controls/inputs/TextFieldControl';
import { Button } from '@mui/material';

const AddCustomerDrawerContainer = ({
  form,
  onSubmit,
  isEditMode,
}: {
  form: any;
  onSubmit: any;
  isEditMode: boolean;
}) => {
  return (
    <FormProvider {...form}>
      <form
        id='add-customer-form'
        className='add-customer-form'
        onSubmit={onSubmit}
      >
        <TextFieldControl label='Ime firme' name='name' />
        <TextFieldControl label='Adresa' name='address' />
        <TextFieldControl label='PIB' name='pib' />
        <TextFieldControl label='Matični broj' name='identificationNumber' />
        <TextFieldControl label='Email' name='email' />
        <TextFieldControl label='Kontakt telefon' name='phone' />
        <TextFieldControl label='Kontakt osoba' name='contactPerson' />
        <TextFieldControl label='Broj žiro računa' name='accountNumber' />
        <TextFieldControl label='IBAN' name='iban' />
        <TextFieldControl label='SWIFT' name='swift' />
        <TextFieldControl label='Rok plaćanja' name='dateOfPayment' />
        <Button type='submit' className='submit-btn'>
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default AddCustomerDrawerContainer;
