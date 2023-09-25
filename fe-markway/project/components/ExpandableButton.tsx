"use client";

import CollapsableContext from "@/context/CollapsableContext";
import { useContext, useState } from "react";

const ExpandableButton = ({ onClick }) => {

    const { isCollapsed } = useContext(CollapsableContext);


    return <span id="expandable-button-container" onClick={onClick}>
        <img src={"./images/collapse-icon.png"} style={{
            transform: `rotate(${!isCollapsed ? 180 : 0}deg)`,
            transition: "all 0.25s"
        }} />
    </span>
}

export default ExpandableButton;