import Image from 'next/image';

const CarriersTableActionContainer = ({
  onClickEdit,
  onClickDelete,
}: {
  onClickEdit: any;
  onClickDelete: any;
}) => {
  return (
    <div className='carriers-table-action-container'>
      <Image
        src={'/images/edit-icon.svg'}
        alt='Edit'
        width={23}
        height={23}
        onClick={onClickEdit}
      />
      <Image
        src={'/images/delete-icon.png'}
        alt='Delete'
        width={23}
        height={23}
        onClick={onClickDelete}
      />
    </div>
  );
};

export default CarriersTableActionContainer;
