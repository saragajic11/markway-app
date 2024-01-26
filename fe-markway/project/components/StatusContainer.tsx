import { Button } from '@mui/material';
import { useEffect, useState } from 'react';
import Status from '../constants/Status';

const StatusContainer = ({
  statusId,
  onClick,
}: {
  statusId: number;
  onClick: any;
}) => {
  const [statusName, setStatusName] = useState('');

  useEffect(() => {
    const statusObj = Status.find((status) => status.id === statusId);
    if (statusObj) {
      setStatusName(statusObj.name);
    }
  }, [statusId]);

  const buttonClassName =
    statusName === 'Nalog poslat'
      ? 'status-1'
      : statusName === 'Čeka na utovar'
      ? 'status-2'
      : statusName === 'Utovareno'
      ? 'status-3'
      : statusName === 'Istovareno'
      ? 'status-4'
      : statusName === 'Fakturisano'
      ? 'status-5'
      : statusName === 'Otkazano'
      ? 'status-6'
      : '';

  return (
    <div id='status-container' onClick={onClick}>
      <Button className={buttonClassName}>{statusName}</Button>
    </div>
  );
};

export default StatusContainer;
