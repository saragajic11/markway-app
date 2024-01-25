import { createContext } from 'react';

const DeleteCarrierDialogContext = createContext({
  isOpenedDeleteDialog: false,
  setOpenedDeleteDialog: (value: boolean) => {},
});

export default DeleteCarrierDialogContext;
