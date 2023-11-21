import { createContext } from "react";

const DrawerContext = createContext({
    isOpened: false,
    setOpened: (value: boolean) => { },
})

export default DrawerContext;