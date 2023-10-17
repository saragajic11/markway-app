import CollapsableContext from '@/context/CollapsableContext';
import { Box, Collapse, Table, TableBody, TableCell, TableHead, TableRow, Typography } from '@mui/material';
import React, { useContext } from 'react';
import LoadOnData from './LoadOnData';
import LoadOffData from './LoadOffData';
import ShipmentDto from '@/model/ShipmentDto';


const TableRowComponent = ({ shipment } : { shipment: ShipmentDto}) => {

    const { isCollapsed } = useContext(CollapsableContext);

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
                    <div>
                        {shipment.shipmentLoadOnLocations.map((shipmentLoadOnLocation, index) => (
                            shipmentLoadOnLocation.type === 0 ? <LoadOnData shipmentLoadOnLocation={shipmentLoadOnLocation} index={index} key={index} /> : <LoadOffData shipmentLoadOnLocation={shipmentLoadOnLocation} index={index} key={index} />
                        ))
                        }
                    </div>
                </div>
            </Box>
        </Collapse>
    </TableCell>

}

export default TableRowComponent;