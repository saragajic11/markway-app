import DeleteCustomerDialogContext from '@/context/DeleteCustomerDialogContext';
import { Button, Dialog, DialogTitle } from '@mui/material';
import { Fragment, useContext } from 'react';

const DeleteCustomerDialog = ({
  customerId,
  confirmDeleteCustomer,
}: {
  customerId: number;
  confirmDeleteCustomer: any;
}) => {
  const { isOpenedDeleteDialog, setOpenedDeleteDialog } = useContext(
    DeleteCustomerDialogContext
  );

  const handleDialogClose = () => {
    setOpenedDeleteDialog(false);
  };

  const handleDeleteCustomer = () => {
    confirmDeleteCustomer(customerId);
  };

  const dialog = (
    <Fragment>
      <Dialog
        open={isOpenedDeleteDialog}
        onClose={handleDialogClose}
        className='delete-dialog-container'
      >
        <div>
          <DialogTitle>
            Da li ste sigurni da želite da obrišete klijenta {customerId}?
          </DialogTitle>

          <Button color='error' onClick={handleDeleteCustomer}>
            Potvrdi
          </Button>
          <Button onClick={handleDialogClose}>Otkaži</Button>
        </div>
      </Dialog>
    </Fragment>
  );
  return dialog;
};

export default DeleteCustomerDialog;
