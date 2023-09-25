"use client"
import { TableComponent } from "@/components";
import { getAllShipments } from "../../services/ContactService";
import { useEffect, useState } from "react";
import ShipmentDto from "../../model/ShipmentDto";

export default function Shipments() {

    const [ shipments, setShipments ] = useState<ShipmentDto [] | []>([]);

    useEffect(() => {
        getAllShipments().then((response) => {
            setShipments(response?.data);
            // response?.data.forEach(elem => {
            //     shipments.push(new ShipmentDto(elem.description, elem.status, elem.merch, elem.merchAmount, elem.vehicleType, elem.licencePlate, elem.income, elem.outcome, elem.profit, elem.carrierID, elem.carrier, elem.customerID, elem.customer, elem.borderCrossingId, elem.borderCrossing, elem.noteId, elem.note));
            // });
        });
        // let data = JSON.parse(response?.data);
        // data.foreach(elem => {
        // })
    }, []);


    return (
        <div id="shipments-container">
            <span>Pregled tura</span>
            <TableComponent shipments={shipments}></TableComponent>
        </div>
    )
}