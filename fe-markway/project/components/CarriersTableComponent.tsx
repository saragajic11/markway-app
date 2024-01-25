import { DataGrid, GridColDef, GridToolbar } from '@mui/x-data-grid';
import CarriersTableActionContainer from './CarriersTableActionContainer';

const CarriersTableComponent = ({
  carriers,
  openDeleteCarrierDialog,
  closeDeleteCarrierDialog,
  setEditMode,
}: {
  carriers: any;
  openDeleteCarrierDialog: any;
  closeDeleteCarrierDialog: any;
  setEditMode: any;
}) => {
  const onClickEdit = (id: number) => {
    setEditMode(true, id);
  };

  const onClickDelete = (id: number) => {
    openDeleteCarrierDialog(id);
  };

  const columns: GridColDef[] = [
    {
      field: 'action',
      headerName: 'Akcije',
      type: 'string',
      renderCell: (params) => (
        <CarriersTableActionContainer
          onClickEdit={() => onClickEdit(params.row.id)}
          onClickDelete={() => onClickDelete(params.row.id)}
        />
      ),
      minWidth: 150,
      width: 150,
      maxWidth: 150,
      sortable: false,
    },
    {
      field: 'companyName',
      headerName: 'Ime firme',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'address',
      headerName: 'Adresa',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'pib',
      headerName: 'PIB',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'identificationNumber',
      headerName: 'Matični broj',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'email',
      headerName: 'Email',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'phone',
      headerName: 'Kontakt telefon',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'contactPerson',
      headerName: 'Kontakt osoba',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'accountNumber',
      headerName: 'Broj žiro računa',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'iban',
      headerName: 'IBAN',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
    {
      field: 'swift',
      headerName: 'SWIFT',
      type: 'string',
      resizable: true,
      minWidth: 200,
      width: 200,
      maxWidth: 200,
    },
  ];

  const rows = !carriers
    ? []
    : carriers?.map((carrier: any) => ({
        id: carrier.id,
        action: (
          <CarriersTableActionContainer
            onClickEdit={() => onClickEdit(carrier.id)}
            onClickDelete={() => onClickDelete(carrier.id)}
          />
        ),
        companyName: carrier.name,
        address: carrier.address,
        pib: carrier.pib,
        identificationNumber: carrier.identificationNumber,
        email: carrier.email,
        phone: carrier.phone,
        contactPerson: carrier.contactPerson,
        accountNumber: carrier.accountNumber,
        iban: carrier.iban,
        swift: carrier.swift,
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

export default CarriersTableComponent;
