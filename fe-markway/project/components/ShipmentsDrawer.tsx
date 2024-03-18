import DrawerContext from '@/context/DrawerContext';
import {
  Button,
  Drawer,
  List,
  ListItem,
  ListItemText,
  Paper,
} from '@mui/material';
import { Fragment, useContext, useEffect, useState } from 'react';
import ShipmentsDrawerContainer from './ShipmentsDrawerContainer';
import { useForm } from 'react-hook-form';
import {
  addShipment,
  getAllBorderCrossings,
  getAllCarriers,
  getAllCustomers,
  getAllCustoms,
  getAllLoadLocations,
} from '@/services/ShipmentService';
import GetCarrierDto from '@/model/GetCarrierDto';
import LoadOnLocationDto from '@/model/LoadOnLocationDto';
import CustomsDto from '@/model/CustomsDto';
import BorderCrossingDto from '@/model/BorderCrossingDto';
import ShipmentDto from '@/model/ShipmentDto';
import AddShipmentDto from '@/model/AddShipmentDto';
import RouteDto from '@/model/RouteDto';
import ShipmentLoadOnLocationDto from '@/model/ShipmentLoadOnLocationDto';
import ShipmentCustomsDto from '@/model/ShipmentCustomsDto';
import CustomerDto from '@/model/CustomerDto';
import NoteDto from '@/model/NoteDto';

const ShipmentsDrawer = ({
  openAddCarrierDialog,
  newCarrier,
  closeAddCarrierDialog,
  startCustomers,
  startCustoms,
  startBorderCrossings,
  startCarriers,
  startLoadLocations,
}: {
  openAddCarrierDialog: any;
  newCarrier: any;
  closeAddCarrierDialog: any;
  startCustomers: any;
  startCustoms: any;
  startBorderCrossings: any;
  startCarriers: any;
  startLoadLocations: any;
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
    setLoadLocations(startLoadLocations);
  }, startLoadLocations);

  useEffect(() => {
    setCustomers(startCustomers);
  }, [startCustomers]);

  useEffect(() => {
    setBorderCrossings(startBorderCrossings);
  }, [startBorderCrossings]);

  useEffect(() => {
    setCustoms(startCustoms);
  }, [startCustoms]);

  useEffect(() => {
    setListOfCarriers(startCarriers);
  }, [startCarriers]);

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
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    status: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    merch: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    merchAmount: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    vehicleType: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    licencePlate: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    income: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    outcome: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    profit: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    carrier: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    customer: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    borderCrossing: {
      required: { value: true, message: 'Ovo polje je obavezno' },
    },
    notes: {
      required: { value: true, message: 'Ovo polje je obavezno' },
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
    const shipmentRoutes = [];

    const shipmentLoadLocation = [];
    const countLoadOnLocations = countNumberOfAttributes(
      data,
      'loadOnLocationDate--'
    );
    const countLoadOffLocations = countNumberOfAttributes(
      data,
      'loadOffLocationDate--'
    );
    const loadOnLocationFirstRoute = 'loadOnLocation--';
    const loadOnLocationDateFirstRoute = 'loadOnLocationDate--';
    const loadOnLocationMerchFirstRoute = 'loadOnLocationMerch--';
    const loadOnLocationMerchAmountFirstRoute = 'loadOnLocationMerchAmount--';
    shipmentLoadLocation.push({
      loadOnLocation: new LoadOnLocationDto(
        data[loadOnLocationFirstRoute].id,
        data[loadOnLocationFirstRoute].name,
        data[loadOnLocationFirstRoute].address
      ),
      type: 0,
      date: data[loadOnLocationDateFirstRoute],
      merch: data[loadOnLocationMerchFirstRoute],
      merchAmount: data[loadOnLocationMerchAmountFirstRoute],
    });
    for (let i = 0; i < countLoadOnLocations - 1; i++) {
      const name = 'loadOnLocation-' + '-' + i;
      const date = 'loadOnLocationDate-' + '-' + i;
      const merch = 'loadOnLocationMerch-' + '-' + i;
      const merchAmount = 'loadOnLocationMerchAmount-' + '-' + i;

      shipmentLoadLocation.push({
        loadOnLocation: new LoadOnLocationDto(
          data[name].id,
          data[name].name,
          data[name].address
        ),
        type: 0,
        date: data[date],
        merch: data[merch],
        merchAmount: data[merchAmount],
      });
    }
    const loadOffLocationFirstRoute = 'loadOffLocation--';
    const loadOffLocationDateFirstRoute = 'loadOffLocationDate--';
    shipmentLoadLocation.push({
      loadOnLocation: new LoadOnLocationDto(
        data[loadOffLocationFirstRoute].id,
        data[loadOffLocationFirstRoute].name,
        data[loadOffLocationFirstRoute].address
      ),
      type: 1,
      date: data[loadOffLocationDateFirstRoute],
      merch: undefined,
      merchAmount: undefined,
    });
    for (let i = 0; i < countLoadOffLocations - 1; i++) {
      const name = 'loadOffLocation' + '-' + i;
      const date = 'loadOffLocationDate' + '-' + i;
      shipmentLoadLocation.push({
        loadOnLocation: new LoadOnLocationDto(
          data[name].id,
          data[name].name,
          data[name].address
        ),
        type: 1,
        date: data[date],
        merch: undefined,
        merchAmount: undefined,
      });
    }
    const shipmentCustoms = [];
    shipmentCustoms.push({
      custom: new CustomsDto(
        data.importDuty.id,
        data.importDuty.name,
        data.importDuty.address
      ),
      type: 0,
    });
    shipmentCustoms.push({
      custom: new CustomsDto(
        data.exportDuty.id,
        data.exportDuty.name,
        data.exportDuty.address
      ),
      type: 1,
    });
    const shipmentNote = { id: 1, description: 'Napomena 1' };
    const shipmentNotes = [shipmentNote];
    const route = new RouteDto(
      data.carrier,
      data.outcome,
      data.outcomeCurrency.name,
      data.vehicleType.name,
      data.licencePlate,
      shipmentLoadLocation,
      shipmentCustoms,
      data.borderCrossings,
      shipmentNote,
      data.dateOfPayment
    );
    shipmentRoutes.push(route);

    //this part will be executed only if shipment contains more than 1 route

    const countRoutes = countNumberOfAttributes(data, 'carrier');
    for (let i = 0; i < countRoutes - 1; i++) {
      const carrier = 'carrier' + i;
      const outcome = 'outcome' + i;
      const outcomeCurrency = 'outcomeCurrency' + i;
      const dateOfPayment = 'dateOfPayment' + i;
      const vehicleType = 'vehicleType' + i;
      const licencePlate = 'licencePlate' + i;
      const currency = 'currency' + i;
      const status = 'status' + i;
      const shipmentLoadLocationAddedRoute = [];
      const shipmentCustomsAddedRoute = [];
      const borderCrossings = 'borderCrossings' + i;
      const countLoadOnLocationsAddedRoute = countNumberOfAttributes(
        data,
        'loadOnLocationDate-' + i + '-'
      );
      const countLoadOffLocationsAddedRoute = countNumberOfAttributes(
        data,
        'loadOffLocationDate-' + i + '-'
      );

      shipmentCustomsAddedRoute.push({
        custom: new CustomsDto(
          data['importDuty' + i].id,
          data['importDuty' + i].name,
          data['importDuty' + i].address
        ),
        type: 0,
      });
      shipmentCustomsAddedRoute.push({
        custom: new CustomsDto(
          data['exportDuty' + i].id,
          data['exportDuty' + i].name,
          data['exportDuty' + i].address
        ),
        type: 1,
      });

      const loadOnLocationAddedRoute = 'loadOnLocation-' + i + '-';
      const loadOnLocationDateAddedRoute = 'loadOnLocationDate-' + i + '-';
      const loadOnLocationMerchAddedRoute = 'loadOnLocationMerch-' + i + '-';
      const loadOnLocationMerchAmountAddedRoute =
        'loadOnLocationMerchAmount-' + i + '-';

      shipmentLoadLocationAddedRoute.push({
        loadOnLocation: new LoadOnLocationDto(
          data[loadOnLocationAddedRoute].id,
          data[loadOnLocationAddedRoute].name,
          data[loadOnLocationAddedRoute].address
        ),
        type: 0,
        date: data[loadOnLocationDateAddedRoute],
        merch: data[loadOnLocationMerchAddedRoute],
        merchAmount: data[loadOnLocationMerchAmountAddedRoute],
      });
      for (let j = 0; j < countLoadOnLocationsAddedRoute - 1; j++) {
        const name = 'loadOnLocation-' + i + '-' + j;
        const date = 'loadOnLocationDate-' + i + '-' + j;
        const merch = 'loadOnLocationMerch-' + i + '-' + j;
        const merchAmount = 'loadOnLocationMerchAmount-' + i + '-' + j;

        shipmentLoadLocationAddedRoute.push({
          loadOnLocation: new LoadOnLocationDto(
            data[name].id,
            data[name].name,
            data[name].address
          ),
          type: 0,
          date: data[date],
          merch: data[merch],
          merchAmount: data[merchAmount],
        });
      }

      const loadOffLocationAddedRoute = 'loadOffLocation-' + i + '-';
      const loadOffLocationDateAddedRoute = 'loadOffLocationDate-' + i + '-';
      shipmentLoadLocationAddedRoute.push({
        loadOnLocation: new LoadOnLocationDto(
          data[loadOffLocationAddedRoute].id,
          data[loadOffLocationAddedRoute].name,
          data[loadOffLocationAddedRoute].address
        ),
        type: 1,
        date: data[loadOffLocationDateAddedRoute],
        merch: undefined,
        merchAmount: undefined,
      });
      for (let j = 0; j < countLoadOffLocationsAddedRoute - 1; j++) {
        const name = 'loadOffLocation-' + i + '-' + j;
        const date = 'loadOffLocationDate-' + i + '-' + j;
        shipmentLoadLocationAddedRoute.push({
          loadOnLocation: new LoadOnLocationDto(
            data[name].id,
            data[name].name,
            data[name].address
          ),
          type: 1,
          date: data[date],
          merch: undefined,
          merchAmount: undefined,
        });
      }

      shipmentRoutes.push(
        new RouteDto(
          data[carrier],
          data[outcome],
          data[outcomeCurrency].name,
          data[vehicleType].name,
          data[licencePlate],
          shipmentLoadLocationAddedRoute,
          shipmentCustoms,
          data[borderCrossings],
          shipmentNote,
          data[dateOfPayment]
        )
      );
    }

    // //TODO: srediti logiku za notes
    // // const shipmentNote = new NoteDto(data.note);
    const shipment = new AddShipmentDto(
      data.externalId,
      data.description,
      data.customer,
      data.status.id,
      data.income,
      data.incomeCurrency.name,
      shipmentRoutes,
      data.profit
    );

    addShipment(shipment).then((response) => {
      //TODO: Implementirati refresh stranice kad se uspesno doda shipment
    });
  };

  const toggleDrawer =
    () => (event: React.KeyboardEvent | React.MouseEvent) => {
      if (
        event.type === 'keydown' &&
        ((event as React.KeyboardEvent).key === 'Tab' ||
          (event as React.KeyboardEvent).key === 'Shift')
      ) {
        return;
      }

      setOpened(!isOpened);
    };

  const drawer = (
    <div>
      <Fragment key='right'>
        <Drawer anchor='right' open={isOpened} onClose={toggleDrawer()}>
          <div id='shipments-drawer-container'>
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
