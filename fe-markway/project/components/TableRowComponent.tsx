import CollapsableContext from '@/context/CollapsableContext';
import { Box, Collapse, Table, TableBody, TableCell, TableHead, TableRow, Typography } from '@mui/material';
import React, { useContext } from 'react';

const TableRowComponent = ({ shipment }) => {

    const { isCollapsed } = useContext(CollapsableContext);

    // return <tr>
    //     <td>{shipment.name}</td>
    //     <td>{shipment.phone}</td>
    //     <td>{shipment.numberrange}</td>
    //     <td>{shipment.numberrange1}</td>

    // </tr>
    return <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
        <Collapse in={!isCollapsed} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
                <Typography variant="h6" gutterBottom component="div">
                    Dodatni podaci
                </Typography>
                <div className='data-container'>
                    <span>Opis: {shipment.description}</span>
                    <span>Status: {shipment.status}</span>
                    <span>Roba: {shipment.merch} </span>
                    <span>Količina robe: {shipment.merchAmount} </span>
                    <span>Tip vozila: {shipment.vehicleType} </span>
                    <span>Registarske tablice: {shipment.licencePlate} </span>
                    <span>Odliv: {shipment.outcome} </span>
                    <span>Profit: {shipment.profit} </span>
                    <span>Prevoznik: {shipment.carrier.name} </span>
                    <span>Granični prelaz: {shipment.borderCrossing.name} </span>
                    <span>Napomena: {shipment.note.description}</span>
                </div>
            </Box>
        </Collapse>
    </TableCell>

}

export default TableRowComponent;