'use client';
import React, { useState } from 'react';
import TableRowComponent from './TableRowComponent';
import ExpandableButton from './ExpandableButton';
import CollapsableContext from '@/context/CollapsableContext';
import { TableCell, TableRow } from '@mui/material';
import { format } from 'date-fns';
import ShipmentDto from '@/model/ShipmentDto';

const TableSection = ({
  shipment,
  openDragDropDialog,
  closeDragDropDialog,
}: {
  shipment: ShipmentDto;
  openDragDropDialog: any;
  closeDragDropDialog: any;
}) => {
  const [isCollapsed, setCollapsed] = useState(true);
  const value = { isCollapsed: isCollapsed, setCollapsed: setCollapsed };

  const onClickOpen = () => {
    setCollapsed(!isCollapsed);
  };

  const formatDate = (date: Date) => {
    const parsedDate = new Date(date);
    return format(parsedDate, 'dd.MM.yyyy. hh:mm');
  };

  const onClickAddFile = () => {
    openDragDropDialog(shipment.id);
  };

  return (
    // <CollapsableContext.Provider value={value}>
    //   <React.Fragment>
    //     <TableRow className='visible'>
    //       <TableCell>
    //         <ExpandableButton onClick={onClickOpen} />
    //       </TableCell>
    //       <TableCell>{shipment.customer.name}</TableCell>
    //       <TableCell>
    //         {shipment.shipmentRoutes.length === 0
    //           ? ''
    //           : shipment.shipmentRoutes[0].shipmentLoadOnLocations[0]
    //               .loadOnLocation.name}
    //       </TableCell>
    //       <TableCell>
    //         {shipment.shipmentRoutes.length === 0
    //           ? ''
    //           : formatDate(
    //               shipment.shipmentRoutes[0].shipmentLoadOnLocations[0].date
    //             )}
    //       </TableCell>
    //       <TableCell>
    //         {shipment.shipmentRoutes.length === 0
    //           ? ''
    //           : shipment.shipmentRoutes[shipment.shipmentRoutes.length - 1]
    //               .shipmentLoadOnLocations[
    //               shipment.shipmentRoutes[shipment.shipmentRoutes.length - 1]
    //                 .shipmentLoadOnLocations.length - 1
    //             ].loadOnLocation.name}
    //       </TableCell>
    //       <TableCell>
    //         {shipment.shipmentRoutes.length === 0
    //           ? ''
    //           : formatDate(
    //               shipment.shipmentRoutes[shipment.shipmentRoutes.length - 1]
    //                 .shipmentLoadOnLocations[
    //                 shipment.shipmentRoutes[shipment.shipmentRoutes.length - 1]
    //                   .shipmentLoadOnLocations.length - 1
    //               ].date
    //             )}
    //       </TableCell>
    //       <TableCell>{shipment.income}</TableCell>
    //       <TableCell onClick={onClickAddFile}>
    //         <img src={'/images/add-document.png'} alt='Add document' />
    //       </TableCell>
    //       <TableCell>
    //         <img src={'/images/edit-icon.svg'} alt='Edit' />
    //       </TableCell>
    //       <TableCell>
    //         <img src={'/images/delete-icon.png'} alt='Delete' />
    //       </TableCell>
    //     </TableRow>

    //     <TableRow className='collapsible'>
    //       {!isCollapsed && <TableRowComponent shipment={shipment} />}
    //     </TableRow>
    //   </React.Fragment>
    // </CollapsableContext.Provider>
    <span>Cao</span>
  );
};

export default TableSection;
