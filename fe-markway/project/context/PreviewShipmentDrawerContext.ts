import { createContext } from 'react';

const PreviewShipmentDrawerContext = createContext({
  isOpened: false,
  setOpened: (value: boolean) => {},
});

export default PreviewShipmentDrawerContext;
