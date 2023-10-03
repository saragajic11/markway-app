"use client"
import { TableComponent } from "@/components";
import { getAllShipments } from "../../services/ShipmentService";
import { useEffect, useState } from "react";
import ShipmentDto from "../../model/ShipmentDto";

export default function Shipments() {

    const [shipments, setShipments] = useState<ShipmentDto[] | []>([]);

    useEffect(() => {
        getAllShipments().then((response) => {
            setShipments(response?.data);
        });
    }, []);


    return (
        <div id="shipments-container">
            <span>Pregled tura</span>
            <TableComponent shipments={shipments}></TableComponent>
        </div>
    )
}