import DeleteCarrierDialogContext from '@/context/DeleteCarrierDialogContext';
import { Button, Dialog, DialogTitle } from '@mui/material';
import { Fragment, useContext } from 'react';

const DeleteCarrierDialog = ({
  carrierId,
  confirmDeleteCarrier,
}: {
  carrierId: number;
  confirmDeleteCarrier: any;
}) => {
  const { isOpenedDeleteDialog, setOpenedDeleteDialog } = useContext(
    DeleteCarrierDialogContext
  );

  const handleDialogClose = () => {
    setOpenedDeleteDialog(false);
  };

  const handleDeleteCarrier = () => {
    confirmDeleteCarrier(carrierId);
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
            Da li ste sigurni da želite da obrišete prevoznika {carrierId}?
          </DialogTitle>

          <Button color='error' onClick={handleDeleteCarrier}>
            Potvrdi
          </Button>
          <Button onClick={handleDialogClose}>Otkaži</Button>
        </div>
      </Dialog>
    </Fragment>
  );
  return dialog;
};

export default DeleteCarrierDialog;
