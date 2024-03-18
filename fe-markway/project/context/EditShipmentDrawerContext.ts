import { createContext } from 'react';

const EditShipmentDrawerContext = createContext({
  isOpened: false,
  setOpened: (value: boolean) => {},
});

export default EditShipmentDrawerContext;
