import { createContext } from "react";

const CollapsableContext = createContext({
    isCollapsed: true,
    setCollapsed: (value: boolean) => { },
})

export default CollapsableContext;