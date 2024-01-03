import { createContext } from 'react';
import { toast } from 'react-toastify';

const ToastContext = createContext({
  isToastOpened: false,
  setToastOpened: (value: boolean, success: boolean, message: string) => {
    success ? toast.success(message) : toast.error(message);
  },
});

export default ToastContext;
