import { createContext } from "react";

const CarrierDialogContext = createContext({
    isOpenedCarrierDialog: false,
    setOpenedCarrierDialog: (value: boolean) => { },
})

export default CarrierDialogContext;