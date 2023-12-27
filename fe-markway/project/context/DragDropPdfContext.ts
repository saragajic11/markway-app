import { createContext } from 'react';

const DragDropPdfContext = createContext({
  isOpenedDragDropDialog: false,
  setOpenedDragDropDialog: (value: boolean) => {},
});

export default DragDropPdfContext;
