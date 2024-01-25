import { Drawer } from '@mui/material';
import { Fragment, useContext, useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { addCarrier, editCarrier } from '@/services/ShipmentService';
import ToastContext from '@/context/ToastContext';
import AddCarrierDrawerContext from '@/context/AddCarrierDrawerContext';
import AddCarrierDrawerContainer from './AddCarrierDrawerContainer';

const AddCarrierDrawer = ({
  carrierId,
  isEditMode,
  carrierToEdit,
}: {
  carrierId: number;
  carrierToEdit: any;
  isEditMode: boolean | false;
}) => {
  const { isOpened, setOpened } = useContext(AddCarrierDrawerContext);
  const { setToastOpened } = useContext(ToastContext);

  const toggleDrawer =
    () => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === 'keydown' &&
        ((event as React.KeyboardEvent).key === 'Tab' ||
          (event as React.KeyboardEvent).key === 'Shift')
      ) {
        return;
      }

      setOpened(!isOpened);
    };

  useEffect(() => {
    if (isEditMode) {
      setValue('name', carrierToEdit?.name);
      setValue('address', carrierToEdit?.address);
      setValue('pib', carrierToEdit?.pib);
      setValue('identificationNumber', carrierToEdit?.identificationNumber);
      setValue('email', carrierToEdit?.email);
      setValue('phone', carrierToEdit?.phone);
      setValue('contactPerson', carrierToEdit?.contactPerson);
      setValue('accountNumber', carrierToEdit?.accountNumber);
      setValue('iban', carrierToEdit?.iban);
      setValue('swift', carrierToEdit?.swift);
    } else {
      form.reset();
    }
  }, [carrierToEdit]);

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

  const onSubmitAddCarrier = (data: any) => {
    isEditMode
      ? editCarrier(carrierId, { ...data, id: carrierId }).then((response) => {
          if (response?.status === 200) {
            //TODO: implementirati refresh stranice u slucaju uspesnog dodavanja klijenta
            setToastOpened(true, true, 'Uspešno izmenjen prevoznik');
          } else {
            setToastOpened(true, false, 'Greška prilikom izmene prevoznika');
          }
          setOpened(false);
        })
      : addCarrier(data).then((response) => {
          if (response?.status === 200) {
            //TODO: implementirati refresh stranice u slucaju uspesnog dodavanja klijenta
            setToastOpened(true, true, 'Uspešno dodat prevoznik');
          } else {
            setToastOpened(true, true, 'Greška prilikom dodavanja prevoznika');
          }
          setOpened(false);
        });
  };

  const drawer = (
    <div>
      <Fragment key={'right'}>
        <Drawer anchor={'right'} open={isOpened} onClose={toggleDrawer()}>
          <div id='add-carrier-drawer-container'>
            <span>Dodaj novog prevoznika</span>
            <AddCarrierDrawerContainer
              form={form}
              onSubmit={handleSubmit(onSubmitAddCarrier)}
              isEditMode={isEditMode}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default AddCarrierDrawer;
