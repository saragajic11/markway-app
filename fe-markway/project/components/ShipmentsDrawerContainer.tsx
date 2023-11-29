import { Button, FormControl, Select, TextField } from "@mui/material";
import { FormProvider, useFormContext } from "react-hook-form";
import SelectControl from "../components/controls/inputs/SelectControl";
import GetCarrierDto from "@/model/GetCarrierDto";
import { useContext, useEffect } from "react";
import CarrierDialogContext from "@/context/CarrierDialogContext";
import Currency from "@/constants/Currency";
import VehicleType from "@/constants/VehicleType";
import Status from "@/constants/Status";
import LoadLocationContainer from "./LoadLocationContainer";

const ShipmentsDrawerContainer = ({
  values,
  setValue,
  control,
  formRules,
  errors,
  form,
  onSubmit,
  listOfStatus,
  listOfCarriers,
  openAddCarrierDialog,
  newCarrier,
  trigger,
  loadLocations,
}) => {
  useEffect(() => {
    setValue("carrier", newCarrier?.id);
    trigger("carrier");
  }, [newCarrier]);

  const addCarrier = () => {
    openAddCarrierDialog();
  };

  const { setOpenedCarrierDialog } = useContext(CarrierDialogContext);

  return (
    <FormProvider {...form}>
      <form id="shipments-form" className="shipments-form" onSubmit={onSubmit}>
        <TextField label="Opis" />
        <TextField label="Klijent" />
        {/* <TextField label="Status" /> */}
        {/* <SelectControl value={values['listOfStatus']} setValue={setValue} name='status' control={control} label={'Status'} options={listOfStatus} nameKey='status' valueKey={'id'} /> */}
        <TextField label="Roba" />
        <TextField
          label="Količina robe"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
        />
        <TextField
          label="Priliv"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
        />

        <hr />

        <span>Dodaj rutu</span>
        <SelectControl
          name="carrier"
          value={values["carrier"]}
          setValue={setValue}
          control={control}
          label={"Prevoznik"}
          options={listOfCarriers}
          nameKey={"name"}
          valueKey={"id"}
          addCarrier={addCarrier}
        />
        <TextField
          label="Odliv"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
        />
        <SelectControl
          name="currency"
          value={values["currency"]}
          setValue={setValue}
          control={control}
          label={"Valuta"}
          options={Currency}
          nameKey={"name"}
          valueKey={"id"}
        />
        <SelectControl
          name="vehicleType"
          value={values["vehicleType"]}
          setValue={setValue}
          control={control}
          label={"Tip vozila"}
          options={VehicleType}
          nameKey={"name"}
          valueKey={"id"}
        />
        <TextField label="Registarske tablice" />
        <hr />
        <span className="load-on-limitter">Utovar</span>
        <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={0}
        />
        <hr />
        <span className="load-on-limitter">Istovar</span>
        <LoadLocationContainer
          values={values}
          setValue={setValue}
          control={control}
          formRules={formRules}
          errors={errors}
          form={form}
          loadLocations={loadLocations}
          loadLocationType={1}
        />
        <hr />
        <SelectControl
          name="status"
          value={values["status"]}
          setValue={setValue}
          control={control}
          label={"Status"}
          options={Status}
          nameKey={"name"}
          valueKey={"id"}
        />

        <hr />

        <TextField
          label="Profit"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
        />
        <TextField label="Beleške" />
        <Button type="submit" className="submit-btn">
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default ShipmentsDrawerContainer;
