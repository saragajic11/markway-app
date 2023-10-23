import { createContext } from "react";

const CollapsableContext = createContext({
    isCollapsed: true,
    setCollapsed: (value) => { },
})

export default CollapsableContext;