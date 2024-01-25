import AddCustomerDrawerContext from '@/context/AddCustomerDrawerContext';
import { Drawer } from '@mui/material';
import { Fragment, useContext, useEffect } from 'react';
import AddCustomerDrawerContainer from './AddCustomerDrawerContainer';
import { useForm } from 'react-hook-form';
import { addCustomer, editCustomer } from '@/services/ShipmentService';
import ToastContext from '@/context/ToastContext';

const AddCustomerDrawer = ({
  customerId,
  isEditMode,
  customerToEdit,
}: {
  customerId: number;
  customerToEdit: any;
  isEditMode: boolean | false;
}) => {
  const { isOpened, setOpened } = useContext(AddCustomerDrawerContext);
  const { setToastOpened } = useContext(ToastContext);

  const toggleDrawer =
    () => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === 'keydown' &&
        ((event as React.KeyboardEvent).key === 'Tab' ||
          (event as React.KeyboardEvent).key === 'Shift')
      ) {
        console.log('?');
        return;
      }

      setOpened(!isOpened);
    };

  useEffect(() => {
    if (isEditMode) {
      setValue('name', customerToEdit?.name);
      setValue('address', customerToEdit?.address);
      setValue('pib', customerToEdit?.pib);
      setValue('identificationNumber', customerToEdit?.identificationNumber);
      setValue('email', customerToEdit?.email);
      setValue('phone', customerToEdit?.phone);
      setValue('contactPerson', customerToEdit?.contactPerson);
      setValue('accountNumber', customerToEdit?.accountNumber);
      setValue('iban', customerToEdit?.iban);
      setValue('swift', customerToEdit?.swift);
    } else {
      form.reset();
    }
  }, [customerToEdit]);

  const form = useForm();
  const {
    handleSubmit,
    setError,
    control,
    getValues,
    setValue,
    formState: { errors },
    trigger,
  } = form;

  //TODO: dodati form rules za dodavanje klijenta
  const formRules = {
    description: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
  };

  const onSubmitAddCustomer = (data: any) => {
    isEditMode
      ? editCustomer(customerId, { ...data, id: customerId }).then(
          (response) => {
            if (response?.status === 200) {
              //TODO: implementirati refresh stranice u slucaju uspesnog dodavanja klijenta
              setToastOpened(true, true, 'Uspešno izmenjen klijent');
            } else {
              setToastOpened(true, false, 'Greška prilikom izmene klijenta');
            }
            setOpened(false);
          }
        )
      : addCustomer(data).then((response) => {
          if (response?.status === 200) {
            //TODO: implementirati refresh stranice u slucaju uspesnog dodavanja klijenta
            setToastOpened(true, true, 'Uspešno dodat klijent');
          } else {
            setToastOpened(true, true, 'Greška prilikom dodavanja klijenta');
          }
          setOpened(false);
        });
  };

  const drawer = (
    <div>
      <Fragment key={'right'}>
        <Drawer anchor={'right'} open={isOpened} onClose={toggleDrawer()}>
          <div id='add-customer-drawer-container'>
            <span>Dodaj novog klijenta</span>
            <AddCustomerDrawerContainer
              form={form}
              onSubmit={handleSubmit(onSubmitAddCustomer)}
              isEditMode={isEditMode}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default AddCustomerDrawer;
