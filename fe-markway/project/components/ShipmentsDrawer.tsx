import DrawerContext from "@/context/DrawerContext";
import {
  Button,
  Drawer,
  List,
  ListItem,
  ListItemText,
  Paper,
} from "@mui/material";
import { Fragment, useContext, useEffect, useState } from "react";
import ShipmentsDrawerContainer from "./ShipmentsDrawerContainer";
import { useForm } from "react-hook-form";
import {
  addShipment,
  getAllBorderCrossings,
  getAllCarriers,
  getAllCustomers,
  getAllCustoms,
  getAllLoadLocations,
} from "@/services/ShipmentService";
import GetCarrierDto from "@/model/GetCarrierDto";
import LoadOnLocationDto from "@/model/LoadOnLocationDto";
import CustomsDto from "@/model/CustomsDto";
import BorderCrossingDto from "@/model/BorderCrossingDto";
import ShipmentDto from "@/model/ShipmentDto";
import AddShipmentDto from "@/model/AddShipmentDto";
import RouteDto from "@/model/RouteDto";
import ShipmentLoadOnLocationDto from "@/model/ShipmentLoadOnLocationDto";
import ShipmentCustomsDto from "@/model/ShipmentCustomsDto";
import CustomerDto from "@/model/CustomerDto";
import NoteDto from "@/model/NoteDto";

const ShipmentsDrawer = ({
  openAddCarrierDialog,
  newCarrier,
  closeAddCarrierDialog,
}) => {
  const { isOpened, setOpened } = useContext(DrawerContext);
  const [listOfStatus, setListOfStatus] = useState([]);
  const [listOfCarriers, setListOfCarriers] = useState<GetCarrierDto[] | []>(
    []
  );
  const [newlyAddedCarrier, setNewlyAddedCarrier] = useState<GetCarrierDto>();
  const [loadLocations, setLoadLocations] = useState<LoadOnLocationDto[] | []>(
    []
  );
  const [customs, setCustoms] = useState<CustomsDto[] | []>([]);
  const [borderCrossings, setBorderCrossings] = useState<
    BorderCrossingDto[] | []
  >([]);
  const [customers, setCustomers] = useState<CustomerDto[] | []>([]);

  useEffect(() => {
    getAllCarriers().then((response) => {
      setListOfCarriers(response?.data);
    });
    getAllLoadLocations().then((response) => {
      setLoadLocations(response?.data);
    });
    getAllCustoms().then((response) => {
      setCustoms(response?.data);
    });
    getAllBorderCrossings().then((response) => {
      setBorderCrossings(response?.data);
    });
    getAllCustomers().then((response) => {
      setCustomers(response?.data);
    })
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
    },
  };

  const countNumberOfAttributes = (data: any, substring: string) => {
    return Object.keys(data).reduce((accumulator, key) => {
      if (key.includes(substring)) {
        return accumulator + 1;
      }
      return accumulator;
    }, 0);
  };

  const onSubmitAddShipmentForm = (data: any) => {
    const shipmentLoadLocation = [];
    const countLoadOnLocations = countNumberOfAttributes(
      data,
      "loadOnLocationDate"
    );
    const countLoadOffLocations = countNumberOfAttributes(
      data,
      "loadOffLocationDate"
    );
    shipmentLoadLocation.push({loadOnLocation:new LoadOnLocationDto(data.loadOnLocation.id, data.loadOnLocation.name, data.loadOnLocation.address), type: 0, date: data.loadOnLocationDate});
    for (let i = 0; i < countLoadOnLocations - 1; i++) {
      const name = "loadOnLocation" + i;
      const date = "loadOnLocationDate" + i
      shipmentLoadLocation.push({loadOnLocation:new LoadOnLocationDto(data[name].id, data[name].name, data[name].address), type: 0, date: data[date]});
    }
    shipmentLoadLocation.push({loadOnLocation: new LoadOnLocationDto(data.loadOffLocation.id, data.loadOffLocation.name, data.loadOffLocation.address), type: 1,  date: data.loadOffLocationDate});
    for (let i = 0; i < countLoadOffLocations - 1; i++) {
      const name = "loadOffLocation" + i;
      const date = "loadOffLocationDate" + i
      shipmentLoadLocation.push({loadOnLocation: new LoadOnLocationDto(data[name].id, data[name].name, data[name].address), type: 1, date: data[date]});
    }
    const shipmentCustoms = [];
    shipmentCustoms.push({custom: new CustomsDto(data.importDuty.id, data.importDuty.name, data.importDuty.address), type: 0});
    shipmentCustoms.push({custom: new CustomsDto(data.exportDuty.id, data.exportDuty.name, data.exportDuty.address), type: 1});
    //TODO: Implementirati mogucnost dodavanja jos Ruta u okviru shipmenta
    const shipmentRoutes = [];
        const route = new RouteDto(
          data.carrier,
          data.outcome,
          data.vehicleType.name,
          data.licencePlate,
          data.currency.name,
          data.status.id,
          shipmentLoadLocation,
          shipmentCustoms,
          data.borderCrossings
        );
        shipmentRoutes.push(route);

        //TODO: srediti logiku za notes
        // const shipmentNote = new NoteDto(data.note);
        const shipmentNote = {id: 1, description: 'Napomena 1'}

        const shipment = new AddShipmentDto(
          data.description,
          data.customer,
          data.merch,
          data.merchAmount,
          data.income,
          shipmentRoutes,
          data.profit,
          shipmentNote
        );

        addShipment(shipment).then((response) => {
          //TODO: Implementirati refresh stranice kad se uspesno doda shipment
        })
      };

  const toggleDrawer =
    () => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === "keydown" &&
        ((event as React.KeyboardEvent).key === "Tab" ||
          (event as React.KeyboardEvent).key === "Shift")
      ) {
        return;
      }

      setOpened(!isOpened);
    };

  const drawer = (
    <div>
      <Fragment key="right">
        <Drawer anchor="right" open={isOpened} onClose={toggleDrawer()}>
          <div id="shipments-drawer-container">
            <span>Dodaj novu turu</span>
            <ShipmentsDrawerContainer
              formRules={formRules}
              errors={errors}
              form={form}
              onSubmit={handleSubmit(onSubmitAddShipmentForm)}
              values={getValues()}
              setValue={setValue}
              control={control}
              listOfStatus={listOfStatus}
              listOfCarriers={listOfCarriers}
              openAddCarrierDialog={openAddCarrierDialog}
              newCarrier={newlyAddedCarrier}
              trigger={trigger}
              loadLocations={loadLocations}
              customs={customs}
              borderCrossings={borderCrossings}
              customers={customers}
            />
          </div>
        </Drawer>
      </Fragment>
    </div>
  );

  return drawer;
};

export default ShipmentsDrawer;
