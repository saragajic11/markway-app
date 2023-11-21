import CarrierDialogContext from "@/context/CarrierDialogContext";
import { addCarrier } from "@/services/ShipmentService";
import { Dialog, DialogContent, DialogContentText, DialogTitle, TextField, DialogActions, Button } from "@mui/material";
import { Fragment, useContext, useState } from "react";
import AddCarrierForm from "./AddCarrierForm";
import { useForm } from "react-hook-form";
import ValidationPatterns from "../constants/ValidationPatterns";

const AddCarrierDialog = ({ addNewCarrier }: { addNewCarrier: any }) => {

    const { isOpenedCarrierDialog, setOpenedCarrierDialog } = useContext(CarrierDialogContext);

    const form = useForm();
    const {
        handleSubmit,
        formState: { errors },
    } = form;

    const formRules = {
        'email': {
            required: { value: true, message: 'Polje je obavezno' },
            pattern: { value: ValidationPatterns.EMAIL, message: 'Neispravan format' }
        },
        'name': { required: { value: true, message: 'Polje je obavezno' } },
    }

    const handleDialogClose = () => {
        setOpenedCarrierDialog(false);
    }

    const onSubmit = (data: any) => {
        addCarrier({ name: data.name, email: data.email }).then(response => {
            if (!response)
                return;
            addNewCarrier(response);
            //TODO: prikazati poruku da je neuspesno

        })
    }

    const dialog = <Fragment>
        <Dialog open={isOpenedCarrierDialog} onClose={handleDialogClose} className="carrier-dialog" >
            <DialogTitle>Dodaj novog prevoznika</DialogTitle>
            <AddCarrierForm handleDialogClose={handleDialogClose} formRules={formRules} errors={errors} form={form} onSubmit={handleSubmit(onSubmit)} />
        </Dialog>
    </Fragment>

    return dialog;


}

export default AddCarrierDialog;