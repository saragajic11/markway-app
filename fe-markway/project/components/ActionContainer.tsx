import Image from 'next/image';

const ActionContainer = ({
  onClickPreview,
  onClickAddFile,
  onClickEdit,
  onClickDelete,
  onClickGeneratePdf,
}: {
  onClickPreview: any;
  onClickAddFile: any;
  onClickEdit: any;
  onClickDelete: any;
  onClickGeneratePdf: any;
}) => {
  return (
    <div className='action-container'>
      <Image src={'/images/view.png'} alt='Details' width={23} height={23} />
      <Image
        src={'/images/add-document.png'}
        alt='Add document'
        width={23}
        height={23}
        onClick={onClickAddFile}
      />
      <Image src={'/images/edit-icon.svg'} alt='Edit' width={23} height={23} />
      <Image
        src={'/images/delete-icon.png'}
        alt='Delete'
        width={23}
        height={23}
        onClick={onClickDelete}
      />
      <Image
        src={'/images/generate-pdf.png'}
        alt='Generate PDF'
        width={23}
        height={23}
        onClick={onClickGeneratePdf}
      />
    </div>
  );
};

export default ActionContainer;
