"use client";
import React, { useState } from 'react';
import TableRowComponent from './TableRowComponent';
import ExpandableButton from './ExpandableButton';
import CollapsableContext from '@/context/CollapsableContext';
import { TableCell, TableRow } from '@mui/material';
import { format } from 'date-fns';
import ShipmentDto from '@/model/ShipmentDto';

const TableSection = ({ shipment } : { shipment: ShipmentDto}) => {

    const [isCollapsed, setCollapsed] = useState(true);
    const value = { isCollapsed: isCollapsed, setCollapsed: setCollapsed };

    const onClickOpen = () => {
        setCollapsed(!isCollapsed);
    }

    const formatDate = (date: Date) => {
        const parsedDate = new Date(date);
        return format(parsedDate, 'dd.MM.yyyy. hh:mm');
    }

    return <CollapsableContext.Provider value={value}>
        <React.Fragment>
            <TableRow className='visible'>
                <TableCell>
                    <ExpandableButton onClick={onClickOpen} />
                </TableCell>
                <TableCell>{shipment.customer.name}</TableCell>
                <TableCell>{shipment.shipmentLoadOnLocations.length === 0 ? '' : shipment.shipmentLoadOnLocations[0].loadOnLocation.name}</TableCell>
                <TableCell>{shipment.shipmentLoadOnLocations.length === 0 ? '' : formatDate(shipment.shipmentLoadOnLocations[0].date)}</TableCell>
                <TableCell>{shipment.shipmentLoadOnLocations.length === 0 ? '' : shipment.shipmentLoadOnLocations[shipment.shipmentLoadOnLocations.length - 1].loadOnLocation.name}</TableCell>
                <TableCell>{shipment.shipmentLoadOnLocations.length === 0 ? '' : formatDate(shipment.shipmentLoadOnLocations[shipment.shipmentLoadOnLocations.length - 1].date)}</TableCell>
                <TableCell>{shipment.income}</TableCell>

            </TableRow>

            <TableRow className='collapsible'>
                {!isCollapsed && <TableRowComponent shipment={shipment} />}
            </TableRow>
        </React.Fragment>
    </CollapsableContext.Provider>
}

export default TableSection;