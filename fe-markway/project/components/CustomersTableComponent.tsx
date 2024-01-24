import { DataGrid, GridColDef, GridToolbar } from '@mui/x-data-grid';
import CustomersTableActionContainer from './CustomersTableActionContainer';

const CustomersTableComponent = ({
  customers,
  openDeleteCustomerDialog,
}: {
  customers: any;
  openDeleteCustomerDialog: any;
  closeDeleteCustomerDialog: any;
}) => {
  const onClickEdit = (id: number) => {};

  const onClickDelete = (id: number) => {
    openDeleteCustomerDialog(id);
  };

  const columns: GridColDef[] = [
    {
      field: 'action',
      headerName: 'Akcije',
      type: 'string',
      renderCell: (params) => (
        <CustomersTableActionContainer
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

  const rows = !customers
    ? []
    : customers?.map((customer: any) => ({
        id: customer.id,
        action: (
          <CustomersTableActionContainer
            onClickEdit={() => onClickEdit(customer.id)}
            onClickDelete={() => onClickDelete(customer.id)}
          />
        ),
        companyName: customer.name,
        address: customer.address,
        pib: customer.pib,
        identificationNumber: customer.identificationNumber,
        email: customer.email,
        phone: customer.phone,
        contactPerson: customer.contactPerson,
        accountNumber: customer.accountNumber,
        iban: customer.iban,
        swift: customer.swift,
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

export default CustomersTableComponent;
