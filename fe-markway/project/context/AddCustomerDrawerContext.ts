import { createContext } from 'react';

const AddCustomerDrawerContext = createContext({
  isOpened: false,
  setOpened: (value: boolean) => {},
});

export default AddCustomerDrawerContext;
