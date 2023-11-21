import { Dialog, DialogContent, DialogContentText, DialogTitle, TextField, DialogActions, Button } from "@mui/material";
import { useState } from "react";
import { FormProvider } from "react-hook-form";
import TextFieldControl from "./controls/inputs/TextFieldControl";

const AddCarrierForm = ({
    handleDialogClose,
    onSubmit,
    form,
    formRules,
    errors

}: { handleDialogClose: any, onSubmit: any, formRules: any, errors: any, form: any }) => {

    return (<FormProvider {...form}>
        <form id="add-carrier-form" className="add-carrier-form" onSubmit={onSubmit}>
            <TextFieldControl
                name="name"
                defaultValue=""
                rules={formRules['name']}
                fullWidth
                margin="normal"
                error={Boolean(errors.name)}
                helperText={errors.name && 'Molimo unesite validno ime'}
                placeholder={'Naziv'}
            />
            <TextFieldControl
                name="email"
                defaultValue=""
                rules={formRules['email']}
                fullWidth
                margin="normal"
                error={Boolean(errors.email)}
                helperText={errors.email && 'Molimo unesite validan email'}
                placeholder={'Email adresa'}

            />
            <Button type="submit">Potvrdi</Button>
            <Button onClick={handleDialogClose}>Poništi</Button>

        </form>
    </FormProvider>
    )
}

export default AddCarrierForm;