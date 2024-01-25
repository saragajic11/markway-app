import { createContext } from 'react';

const AddCarrierDrawerContext = createContext({
  isOpened: false,
  setOpened: (value: boolean) => {},
});

export default AddCarrierDrawerContext;
