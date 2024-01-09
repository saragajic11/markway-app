import DeleteShipmentDialogContext from '@/context/DeleteShipmentDialogContext';
import { Button, Dialog, DialogTitle } from '@mui/material';
import { Fragment, useContext } from 'react';

const DeleteShipmentDialog = ({
  shipmentId,
  confirmDeleteShipment,
}: {
  shipmentId: number;
  confirmDeleteShipment: any;
}) => {
  const { isOpenedDeleteDialog, setOpenedDeleteDialog } = useContext(
    DeleteShipmentDialogContext
  );

  const handleDialogClose = () => {
    setOpenedDeleteDialog(false);
  };

  const handleDeleteShipment = () => {
    confirmDeleteShipment(shipmentId);
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
            Da li ste sigurni da želite da obrišete turu {shipmentId}?
          </DialogTitle>

          <Button color='error' onClick={handleDeleteShipment}>
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
