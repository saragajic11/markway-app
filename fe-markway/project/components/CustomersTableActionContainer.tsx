import Image from 'next/image';

const CustomersTableActionContainer = ({
  onClickEdit,
  onClickDelete,
}: {
  onClickEdit: any;
  onClickDelete: any;
}) => {
  return (
    <div className='customers-table-action-container'>
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

export default CustomersTableActionContainer;
