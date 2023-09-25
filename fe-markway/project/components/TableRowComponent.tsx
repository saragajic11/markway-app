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
                    <span>Podatak 1</span>
                    <span>Podatak 1</span>
                    <span>Podatak 1</span>
                    <span>Podatak 1</span>
                    <span>Podatak 1</span>
                </div>
            </Box>
        </Collapse>
    </TableCell>

}

export default TableRowComponent;