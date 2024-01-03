import ShipmentDto from '@/model/ShipmentDto';
import ExpandableButton from './ExpandableButton';
import {
  DataGrid,
  GridColDef,
  GridToolbar,
  GridToolbarColumnsButton,
  GridToolbarContainer,
} from '@mui/x-data-grid';
import { useState } from 'react';
import { format } from 'date-fns';
import Image from 'next/image';

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

  const columns: GridColDef[] = [
    {
      field: 'Proširi',
      headerName: '',
      type: 'string',
      renderCell: () => <ExpandableButton onClick={onClickOpen} />,
      minWidth: 80,
      width: 80,
      maxWidth: 80,
      sortable: false,
      hideable: false,
    },
    {
      field: 'customer',
      headerName: 'Nalogodavac',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'loadOnLocation',
      headerName: 'Mesto utovara',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'loadOnDate',
      headerName: 'Datum utovara',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'loadOffLocation',
      headerName: 'Mesto istovara',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'loadOffDate',
      headerName: 'Datum istovara',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'income',
      headerName: 'Prihod',
      type: 'string',
      resizable: true,
      minWidth: 150,
      width: 150,
      maxWidth: 150,
    },
    {
      field: 'Dodaj PDF',
      headerName: '',
      type: 'string',
      renderCell: (params) => (
        <Image
          src={'/images/add-document.png'}
          alt='Add document'
          onClick={() => onClickAddFile(params.row.id)}
          width={25}
          height={25}
        />
      ),
      minWidth: 80,
      width: 80,
      maxWidth: 80,
      resizable: true,
      sortable: false,
      hideable: false,
    },
    {
      field: 'Izmeni',
      headerName: '',
      type: 'string',
      renderCell: () => (
        <Image
          src={'/images/edit-icon.svg'}
          alt='Edit'
          width={25}
          height={25}
        />
      ),
      resizable: true,
      minWidth: 80,
      width: 80,
      maxWidth: 80,
      sortable: false,
      hideable: false,
    },
    {
      field: 'Obriši',
      headerName: '',
      type: 'string',
      renderCell: () => (
        <Image
          src={'/images/delete-icon.png'}
          alt='Delete'
          width={25}
          height={25}
        />
      ),
      resizable: true,
      minWidth: 80,
      width: 80,
      maxWidth: 80,
      sortable: false,
      hideable: false,
    },
  ];

  const rows = !shipments
    ? []
    : shipments?.map((shipment) => ({
        id: shipment.id,
        expand: <ExpandableButton onClick={onClickOpen} />,
        customer: shipment.customer.name,
        loadOnLocation:
          shipment.shipmentRoutes?.length === 0
            ? ''
            : shipment.shipmentRoutes[0].shipmentLoadOnLocations[0]
                .loadOnLocation.name,
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
    <DataGrid
      rows={rows}
      columns={columns}
      autoPageSize
      checkboxSelection={false}
      style={{ height: '100%', width: '80%' }}
      slots={{
        toolbar: GridToolbar,
      }}
    />
  );
};

export default TableComponent;
