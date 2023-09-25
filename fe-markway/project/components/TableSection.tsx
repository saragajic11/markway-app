"use client";
import React, { useContext, useState } from 'react';
import { data } from "../data/dumbdata";
import TableRowComponent from './TableRowComponent';
import ExpandableButton from './ExpandableButton';
import CollapsableContext from '@/context/CollapsableContext';
import { TableBody, TableCell, TableRow } from '@mui/material';

const TableSection = ({ shipment }) => {

    const [isCollapsed, setCollapsed] = useState(true);
    const value = { isCollapsed: isCollapsed, setCollapsed: setCollapsed };

    const onClickOpen = () => {
        setCollapsed(!isCollapsed);
    }


    // return <CollapsableContext.Provider value={value}>
    //     <tbody>
    //         <tr>
    //             <ExpandableButton onClick={onClickOpen}/>
    //             <td><b>Person : 1</b></td>
    //             <td>{isCollapsed}</td>
    //             <td></td>
    //             <td></td>
    //         </tr>
    //         {!isCollapsed && <TableRow shipment={shipment} />}
    //     </tbody>
    // </CollapsableContext.Provider >
    return <CollapsableContext.Provider value={value}>
        <React.Fragment>
                <TableRow className='visible'>
                    <TableCell>
                        <ExpandableButton onClick={onClickOpen} />
                    </TableCell>
                    <TableCell>{shipment.description}</TableCell>
                    <TableCell>{data.phone}</TableCell>
                    <TableCell>{data.numberrange}</TableCell>
                    <TableCell>{data.numberrange1}</TableCell>
                </TableRow>

                <TableRow className='collapsible'>
                    {!isCollapsed && <TableRowComponent shipment={shipment} />}
                </TableRow>
        </React.Fragment>
    </CollapsableContext.Provider>
}

export default TableSection;