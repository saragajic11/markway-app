import { createContext } from 'react';

const DeleteShipmentDialogContext = createContext({
  isOpenedDeleteDialog: false,
  setOpenedDeleteDialog: (value: boolean) => {},
});

export default DeleteShipmentDialogContext;
