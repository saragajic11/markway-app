import NoteDto from '@/model/NoteDto';

const NotesContainer = ({ note }: { note: NoteDto }) => {
  return (
    <div className='notes-container'>
      <span>{note.description}</span>
    </div>
  );
};

export default NotesContainer;
