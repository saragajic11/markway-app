import AddCustomerDrawerContext from '@/context/AddCustomerDrawerContext';
import { Drawer } from '@mui/material';
import { Fragment, useContext } from 'react';
import AddCustomerDrawerContainer from './AddCustomerDrawerContainer';
import { useForm } from 'react-hook-form';
import { addCustomer } from '@/services/ShipmentService';
import ToastContext from '@/context/ToastContext';

const AddCustomerDrawer = () => {
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
    addCustomer(data).then((response) => {
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
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default AddCustomerDrawer;
