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

const TableComponent = ({
  shipments,
  openDragDropDialog,
  closeDragDropDialog,
}: {
  shipments: ShipmentDto[];
  openDragDropDialog: any;
  closeDragDropDialog: any;
}) => {
  return (
    <TableContainer component={Paper} id='table-container'>
      <Table aria-label='collapsible table'>
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Nalogodavac</TableCell>
            <TableCell>Mesto utovara</TableCell>
            <TableCell>Datum utovara</TableCell>
            <TableCell>Mesto istovara</TableCell>
            <TableCell>Datum istovara</TableCell>
            <TableCell>Prihod</TableCell>
            <TableCell />
            <TableCell />
            <TableCell />
          </TableRow>
        </TableHead>
        <TableBody>
          {shipments.map((shipment) => (
            <TableSection
              shipment={shipment}
              key={shipment.id}
              openDragDropDialog={openDragDropDialog}
              closeDragDropDialog={closeDragDropDialog}
            />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default TableComponent;
