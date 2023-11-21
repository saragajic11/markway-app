import DrawerContext from "@/context/DrawerContext";
import { Button, Drawer, List, ListItem, ListItemText, Paper } from "@mui/material";
import { Fragment, useContext, useEffect, useState } from "react";
import ShipmentsDrawerContainer from "./ShipmentsDrawerContainer";
import { useForm } from "react-hook-form";
import { getAllCarriers } from "@/services/ShipmentService";
import GetCarrierDto from "@/model/GetCarrierDto";

const ShipmentsDrawer = ({ openAddCarrierDialog, newCarrier, closeAddCarrierDialog }) => {

    const { isOpened, setOpened } = useContext(DrawerContext);
    const [listOfStatus, setListOfStatus] = useState([]);
    const [listOfCarriers, setListOfCarriers] = useState<GetCarrierDto[] | []>([]);
    const [newlyAddedCarrier, setNewlyAddedCarrier] = useState<GetCarrierDto>();

    useEffect(() => {
        getAllCarriers().then((response) => {
            setListOfCarriers(response?.data);
        });
    }, []);

    useEffect(() => {
        if (newCarrier) {
            setListOfCarriers((existingList) => [...existingList, newCarrier]);
            setNewlyAddedCarrier(newCarrier);
            closeAddCarrierDialog();
        }
    }, [newCarrier]);

    const form = useForm();
    const {
        handleSubmit,
        setError,
        control,
        getValues,
        setValue,
        formState: { errors },
        trigger,
    } = form;

    const formRules = {
        description: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        status: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        merch: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        merchAmount: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        vehicleType: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        licencePlate: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        income: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        outcome: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        profit: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        carrier: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        customer: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        borderCrossing: {
            required: { value: true, message: "Ovo polje je obavezno" },
        },
        notes: {
            required: { value: true, message: "Ovo polje je obavezno" },
        }
    }

    const onSubmitAddShipmentForm = (data: any) => {
        console.log("Submitovano");
    }

    const toggleDrawer = () => (event: React.KeyboardEvent | React.MouseEvent) => {
        if (event.type === 'keydown' && ((event as React.KeyboardEvent).key === 'Tab' || (event as React.KeyboardEvent).key === 'Shift')) {
            return;
        }

        setOpened(!isOpened);
    };

    const drawer = (
        <div>
            <Fragment key='right'>
                <Drawer anchor="right" open={isOpened} onClose={toggleDrawer()}>
                    <div id="shipments-drawer-container">
                        <span>Dodaj novu turu</span>
                        <ShipmentsDrawerContainer formRules={formRules} errors={errors} form={form} onSubmit={handleSubmit(onSubmitAddShipmentForm)} values={getValues()} setValue={setValue} control={control} listOfStatus={listOfStatus} listOfCarriers={listOfCarriers} openAddCarrierDialog={openAddCarrierDialog} newCarrier={newlyAddedCarrier} trigger={trigger} />
                    </div>
                </Drawer >
            </Fragment>
        </div >
    )

    return drawer;
}

export default ShipmentsDrawer;