import { createContext } from 'react';
import { toast } from 'react-toastify';

const ToastContext = createContext({
  isToastOpened: false,
  setToastOpened: (value: boolean, success: boolean, message: string) => {
    console.log('Evo mee', value, success, message);
    success ? toast.success(message) : toast.error(message);
  },
});

export default ToastContext;
