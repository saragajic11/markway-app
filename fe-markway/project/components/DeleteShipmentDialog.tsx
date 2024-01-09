import DeleteShipmentDialogContext from '@/context/DeleteShipmentDialogContext';
import { Button, Dialog, DialogTitle } from '@mui/material';
import { Fragment, useContext } from 'react';

const DeleteShipmentDialog = ({ shipmentId }: { shipmentId: number }) => {
  const { isOpenedDeleteDialog, setOpenedDeleteDialog } = useContext(
    DeleteShipmentDialogContext
  );

  const handleDialogClose = () => {
    setOpenedDeleteDialog(false);
  };

  const handleDeleteShipment = () => {};

  const dialog = (
    <Fragment>
      <Dialog
        open={isOpenedDeleteDialog}
        onClose={handleDialogClose}
        className='delete-dialog-container'
      >
        <div>
          <DialogTitle>
            Da li ste sigurni da želite da obrišete turu {shipmentId}?
          </DialogTitle>

          <Button type='submit' onClick={handleDeleteShipment}>
            Potvrdi
          </Button>
          <Button onClick={handleDialogClose}>Otkaži</Button>
        </div>
      </Dialog>
    </Fragment>
  );
  return dialog;
};

export default DeleteShipmentDialog;
