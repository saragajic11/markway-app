import CollapsableContext from '@/context/CollapsableContext';
import {
  Box,
  Collapse,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from '@mui/material';
import React, { useContext } from 'react';
import LoadOnData from './LoadOnData';
import LoadOffData from './LoadOffData';
import ShipmentDto from '@/model/ShipmentDto';
import RouteContainer from './RouteContainer';

const TableRowComponent = ({ shipment }: { shipment: ShipmentDto }) => {
  const { isCollapsed } = useContext(CollapsableContext);
  //TODO: Implementirati mapiranje notes, vec sam napravila NotesContainer
  return (
    <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
      <Collapse in={!isCollapsed} timeout='auto' unmountOnExit>
        <Box sx={{ margin: 1 }}>
          <Typography variant='h6' gutterBottom component='div'>
            Dodatni podaci
          </Typography>
          <div className='data-container'>
            <span>Opis: {shipment.description}</span>
            <span>Roba: {shipment.merch} </span>
            <span>Količina robe: {shipment.merchAmount} </span>
            <span>Priliv: {shipment.income}</span>
            <span>Nalogodavac: {shipment.customer.name}</span>
            <div>
              {shipment.shipmentRoutes.map((route, index) => (
                <RouteContainer route={route} index={index} key={index} />
              ))}
            </div>
            <span>Profit: {shipment.profit}</span>
            <span>Beleška: {shipment.note.description}</span>
          </div>
        </Box>
      </Collapse>
    </TableCell>
  );
};

export default TableRowComponent;
