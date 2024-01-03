import { data } from '../data/dumbdata';
import TableSection from './TableSection';
import Table from '@mui/material/Table';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import TableCell from '@mui/material/TableCell';
import TableBody from '@mui/material/TableBody';
import ShipmentDto from '@/model/ShipmentDto';
import ExpandableButton from './ExpandableButton';
import { DataGrid } from '@mui/x-data-grid';
import { useState } from 'react';
import { format } from 'date-fns';

const TableComponent = ({
  shipments,
  openDragDropDialog,
  closeDragDropDialog,
}: {
  shipments: ShipmentDto[];
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

  const onClickAddFile = (id: number) => {
    openDragDropDialog(id);
  };

  const columns = [
    {
      field: 'expand',
      headerName: '',
      type: 'string',
      renderCell: () => <ExpandableButton onClick={onClickOpen} />,
    },
    { field: 'customer', headerName: 'Nalogodavac', type: 'string' },
    { field: 'loadOnLocation', headerName: 'Mesto utovara', type: 'string' },
    { field: 'loadOnDate', headerName: 'Datum utovara', type: 'string' },
    { field: 'loadOffLocation', headerName: 'Mesto istovara', type: 'string' },
    { field: 'loadOffDate', headerName: 'Datum istovara', type: 'string' },
    { field: 'income', headerName: 'Prihod', type: 'number' },
    {
      field: 'addPdfIcon',
      headerName: '',
      type: 'string',
      renderCell: (params) => (
        <img
          src={'/images/add-document.png'}
          alt='Add document'
          onClick={() => onClickAddFile(params.row.id)}
        />
      ),
    },
    {
      field: 'editIcon',
      headerName: '',
      type: 'string',
      renderCell: () => <img src={'/images/edit-icon.svg'} alt='Edit' />,
    },
    {
      field: 'deleteIcon',
      headerName: '',
      type: 'string',
      renderCell: () => <img src={'/images/delete-icon.png'} alt='Delete' />,
    },
  ];

  const rows = 
  !shipments ? [] : shipments?.map((shipment) => ({
    expand: <ExpandableButton onClick={onClickOpen} />,
    customer: shipment.customer.name,
    loadOnLocation:
      shipment.shipmentRoutes?.length === 0
        ? ''
        : shipment.shipmentRoutes[0].shipmentLoadOnLocations[0].loadOnLocation
            .name,
    loadOnDate:
      shipment.shipmentRoutes?.length === 0
        ? ''
        : formatDate(
            shipment.shipmentRoutes[0].shipmentLoadOnLocations[0].date
          ),
    loadOffLocation:
      shipment.shipmentRoutes?.length === 0
        ? ''
        : shipment.shipmentRoutes[shipment?.shipmentRoutes?.length - 1]
            .shipmentLoadOnLocations[
            shipment.shipmentRoutes[shipment.shipmentRoutes?.length - 1]
              .shipmentLoadOnLocations?.length - 1
          ].loadOnLocation.name,
    loadOffDate:
      shipment.shipmentRoutes?.length === 0
        ? ''
        : formatDate(
            shipment.shipmentRoutes[shipment.shipmentRoutes?.length - 1]
              .shipmentLoadOnLocations[
              shipment.shipmentRoutes[shipment.shipmentRoutes?.length - 1]
                .shipmentLoadOnLocations?.length - 1
            ].date
          ),
    income: shipment.income,
    addPdfIcon: (
      <img
        src={'/images/add-document.png'}
        alt='Add document'
        onClick={() => onClickAddFile(shipment.id)}
      />
    ),
    editIcon: <img src={'/images/edit-icon.svg'} alt='Edit' />,
    deleteIcon: <img src={'/images/delete-icon.png'} alt='Delete' />,
  }));
  return (
    // <TableContainer component={Paper} id='table-container'>
    //   <Table aria-label='collapsible table'>
    //     <TableHead>
    //       <TableRow>
    //         <TableCell />
    //         <TableCell>Nalogodavac</TableCell>
    //         <TableCell>Mesto utovara</TableCell>
    //         <TableCell>Datum utovara</TableCell>
    //         <TableCell>Mesto istovara</TableCell>
    //         <TableCell>Datum istovara</TableCell>
    //         <TableCell>Prihod</TableCell>
    //         <TableCell />
    //         <TableCell />
    //         <TableCell />
    //       </TableRow>
    //     </TableHead>
    //     <TableBody>
    //       {shipments?.map((shipment) => (
    //         <TableSection
    //           shipment={shipment}
    //           key={shipment.id}
    //           openDragDropDialog={openDragDropDialog}
    //           closeDragDropDialog={closeDragDropDialog}
    //         />
    //       ))}
    //     </TableBody>
    //   </Table>
    // </TableContainer>
    <DataGrid
      rows={rows}
      columns={columns}
      autoPageSize
      checkboxSelection
      components={{
        Row: ({ row, ...props }) => (
          <div>
            <TableSection
              shipment={row}
              key={row.id}
              openDragDropDialog={openDragDropDialog}
              closeDragDropDialog={closeDragDropDialog}
            />
          </div>
        ),
      }}
    />
  );
};

export default TableComponent;
