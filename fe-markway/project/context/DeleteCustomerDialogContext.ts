import { createContext } from 'react';

const DeleteCustomerDialogContext = createContext({
  isOpenedDeleteDialog: false,
  setOpenedDeleteDialog: (value: boolean) => {},
});

export default DeleteCustomerDialogContext;
