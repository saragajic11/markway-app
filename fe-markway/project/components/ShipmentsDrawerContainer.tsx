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
import TextFieldControl from "./controls/inputs/TextFieldControl";

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
  customs,
  borderCrossings,
  customers,
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
        <TextFieldControl label="Opis" name="description" />
        <SelectControl name="customer" value={values["customer"]} setValue={setValue} control={control} label="Klijent" options={customers}
          nameKey={"name"}
          valueKey={"id"}/>
        {/* <TextField label="Status" /> */}
        {/* <SelectControl value={values['listOfStatus']} setValue={setValue} name='status' control={control} label={'Status'} options={listOfStatus} nameKey='status' valueKey={'id'} /> */}
        <TextFieldControl label="Roba" name="merch" />
        <TextFieldControl
          label="Količina robe"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
          name="merchAmount"
        />
        <TextFieldControl
          label="Priliv"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
          name="income"
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
        <TextFieldControl
          label="Odliv"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
          name="outcome"
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
        <TextFieldControl label="Registarske tablice" name="licencePlate" />
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
          name="importDuty"
          value={values["importDuty"]}
          setValue={setValue}
          control={control}
          label={"Uvozna carina"}
          options={customs}
          nameKey={"name"}
          valueKey={"id"}
        />
        <SelectControl
          name="exportDuty"
          value={values["exportDuty"]}
          setValue={setValue}
          control={control}
          label={"Izvozna carina"}
          options={customs}
          nameKey={"name"}
          valueKey={"id"}
        />
        <SelectControl
          name="borderCrossings"
          value={values["borderCrossings"]}
          setValue={setValue}
          control={control}
          label={"Granični prelaz"}
          options={borderCrossings}
          nameKey={"name"}
          valueKey={"id"}
        />
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

        <TextFieldControl
          label="Profit"
          type="number"
          InputProps={{
            inputProps: { min: 0 },
          }}
          name="profit"
        />
        <TextFieldControl label="Beleške" name="note" />
        <Button type="submit" className="submit-btn">
          Potvrdi
        </Button>
      </form>
    </FormProvider>
  );
};

export default ShipmentsDrawerContainer;
