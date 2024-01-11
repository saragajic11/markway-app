import DragDropPdfContext from '@/context/DragDropPdfContext';
import { Button, Dialog, DialogTitle } from '@mui/material';
import { Fragment, useContext, useEffect, useRef, useState } from 'react';
import DragDropForm from './DragDropForm';
import { attachFile } from '@/services/ShipmentService';

const DragDropPdfDialog = ({ shipmentId }: { shipmentId: number }) => {
  const { isOpenedDragDropDialog, setOpenedDragDropDialog } =
    useContext(DragDropPdfContext);

  const [dragActive, setDragActive] = useState(false);
  const inputRef = useRef<any>(null);
  const [files, setFiles] = useState<any>([]);

  const handleDragEnter = (e: any) => {
    e.preventDefault();
    e.stopPropagation();
    setDragActive(true);
  };

  const handleDrop = (e: any) => {
    e.preventDefault();
    e.stopPropagation();
    setDragActive(false);
    if (e.dataTransfer.files && e.dataTransfer.files[0]) {
      for (let i = 0; i < e.dataTransfer.files['length']; i++) {
        setFiles((prevState: any) => [...prevState, e.dataTransfer.files[i]]);
      }
    }
  };

  const handleDragLeave = (e: any) => {
    e.preventDefault();
    e.stopPropagation();
    setDragActive(false);
  };

  const handleDragOver = (e: any) => {
    e.preventDefault();
    e.stopPropagation();
    setDragActive(true);
  };

  const handleDialogClose = () => {
    setOpenedDragDropDialog(false);
  };

  const handleChange = (e: any) => {
    e.preventDefault();
    if (e.target.files && e.target.files[0]) {
      for (let i = 0; i < e.target.files['length']; i++) {
        setFiles((prevState: any) => [...prevState, e.target.files[i]]);
      }
    }
  };

  const openFileExplorer = () => {
    inputRef.current.value = '';
    inputRef.current.click();
  };

  const handleSubmitFile = (e: any) => {
    if (files.length === 0) {
      //nije submitovan nijedan fajl
    } else {
      attachFile(files[0]).then((response) => {});
    }
  };

  function removeFile(fileName: any, idx: any) {
    const newArr = [...files];
    newArr.splice(idx, 1);
    setFiles([]);
    setFiles(newArr);
  }

  const dialog = (
    <Fragment>
      <Dialog
        open={isOpenedDragDropDialog}
        onClose={handleDialogClose}
        className={`drag-drop-dialog ${dragActive ? 'active' : ''}`}
        onDragEnter={handleDragEnter}
        onDrop={handleDrop}
        onDragLeave={handleDragLeave}
        onDragOver={handleDragOver}
      >
        <div className={`${dragActive ? 'active' : ''}`}>
          <DialogTitle>Dodaj dokument za turu {shipmentId}</DialogTitle>
          <input
            placeholder='fileInput'
            className='hidden'
            ref={inputRef}
            type='file'
            multiple={true}
            onChange={handleChange}
            accept='.pdf'
          />
          <p>
            Prevuci ili <span onClick={openFileExplorer}>odaberi</span> dokument
          </p>

          <div className='files-container'>
            {files.map((file: any, idx: any) => (
              <div key={idx} className='flex flex-row space-x-5'>
                <span>{file.name}</span>
                <span
                  className='remove-btn'
                  onClick={() => removeFile(file.name, idx)}
                >
                  remove
                </span>
              </div>
            ))}
          </div>

          <Button type='submit' onClick={handleSubmitFile}>
            Potvrdi
          </Button>
        </div>
      </Dialog>
    </Fragment>
  );
  return dialog;
};

export default DragDropPdfDialog;
