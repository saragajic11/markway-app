import { data } from "../data/dumbdata";
import TableSection from "./TableSection";
import Table from '@mui/material/Table';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import TableCell from '@mui/material/TableCell';
import TableBody from '@mui/material/TableBody';

const TableComponent = ({shipments}) => {
    // return <table id="table-container">
    //     <thead>
    //         <th>Nalogodavac</th>
    //         <th>Status</th>
    //         <th>Priliv</th>
    //         <th>Odliv</th>
    //         <th>Profit</th>
    //         <td></td>
    //     </thead>
    //     {data.map((shipment, index)=> (
    //         <TableSection shipment={shipment} index={index}/>
    //     ))}
    // </table>
    return <TableContainer component={Paper} id="table-container">
        <Table aria-label="collapsible table">
            <TableHead>
                <TableRow>
                    <TableCell />
                    <TableCell>Nalogodavac</TableCell>
                    <TableCell>Mesto utovara</TableCell>
                    <TableCell>Datum utovara</TableCell>
                    <TableCell>Mesto istovara</TableCell>
                    <TableCell>Datum istovara</TableCell>
                    <TableCell>Prihod</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {shipments.map((shipment, key, index) => (
                    <TableSection shipment={shipment}/>
                ))}
            </TableBody>
        </Table>
    </TableContainer>
}

export default TableComponent;