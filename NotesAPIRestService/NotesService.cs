using NotesAPIRestService.Requests;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesAPIRestService
{
    public interface INotesService
    {
        Task<NotesModel> AddNewNote(AddNoteRequests request);
        Task<NotesModel> EditNote(EditNoteRequest request);
        Task<bool> DeleteNote(DeleteNoteRequest request);
        Task<NotesModel> GetNote(GetNoteRequest request);
        Task<List<NotesModel>> GetNotes(GetNotesRequests request);
    }
    // since this is the only service for the api, we do not need to 
    // structure it under neath a folder called services
    public class NotesService : INotesService
    {
        private readonly IDbConnectionFactory _factory;
        public NotesService(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<NotesModel> AddNewNote(AddNoteRequests request)
        {
            using var db = await _factory.OpenDbConnectionAsync();
            var newNote = new NotesModel
            {
                Note = request.Note
            };
            var id = await db.InsertAsync(newNote, selectIdentity: true);
            newNote.NoteId = (int)id;
            return newNote;
        }

        public async Task<bool> DeleteNote(DeleteNoteRequest request)
        {
            using var db = await _factory.OpenDbConnectionAsync();
            await db.DeleteAsync<NotesModel>(x => x.NoteId == request.NoteId);

            return true;
        }

        public async Task<NotesModel> EditNote(EditNoteRequest request)
        {
            using var db = await _factory.OpenDbConnectionAsync();
            var note = await db.SingleAsync<NotesModel>(x => x.NoteId == request.NoteId);
            var response = new NotesModel();
            if (note == null)
            {
                // need to return a message saying that the note does not exists
                response.Note = $"unable to edit the following note because it was not found: {request.NoteId}";
                return note;
            }
            note.Note = request.Note;
            await db.UpdateAsync(note);
            return note;
        }

        public async Task<NotesModel> GetNote(GetNoteRequest request)
        {
            using var db = await _factory.OpenDbConnectionAsync();

            return await db.SingleAsync<NotesModel>(x => x.NoteId == request.NoteId);
        }

        public async Task<List<NotesModel>> GetNotes(GetNotesRequests request)
        {
            using var db = await _factory.OpenDbConnectionAsync();
            var notes = await db.SelectAsync<NotesModel>();

            return notes;
        }
    }
}
