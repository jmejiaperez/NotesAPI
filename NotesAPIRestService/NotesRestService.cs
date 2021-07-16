using NotesAPIRestService.Requests;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesAPIRestService
{
    [CompressResponse]
    public class NotesRestService : Service
    {
        private readonly INotesService _notesService;
        public NotesRestService(INotesService notesService)
        {
            _notesService = notesService;
        }

        /// <summary>
        /// this endpoint is in charge of getting a single note from a noteid in the request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<NotesModel> Get(GetNoteRequest request)
        {
            if (request.NoteId == 0)
            {
                throw new ArgumentNullException($"{nameof(request.NoteId)} is missing");
            }
            return await _notesService.GetNote(request);
        }

        /// <summary>
        /// this endpoint is in charge of getting all notes
        /// </summary>
        /// <param name="request"></param>
        /// <returns>a list of the NotesModels</returns>
        public async Task<List<NotesModel>> Get(GetNotesRequests request)
        {
            return await _notesService.GetNotes(request);
        }

        /// <summary>
        /// if a note needs to be edited, this endpoint takes care of that
        /// a noteid is needed in order to modify the necessary note with the modified note details
        /// </summary>
        /// <param name="request"></param>
        /// <returns>a model of the NotesModel</returns>
        public async Task<NotesModel> Post(EditNoteRequest request)
        {
            if (request.NoteId == 0)
            {
                throw new ArgumentNullException($"{nameof(request.NoteId)} is missing");
            }
            if (string.IsNullOrEmpty(request.Note))
            {
                throw new ArgumentNullException($"{nameof(request.Note)} is missing");
            }
            return await _notesService.EditNote(request);
        }

        /// <summary>
        /// if a new note is needed, this endpoint is in charge of adding it
        /// </summary>
        /// <param name="request"></param>
        /// <returns>a model of the NotesModel</returns>
        public async Task<NotesModel> Put(AddNoteRequests request)
        {
            if (string.IsNullOrEmpty(request.Note))
            {
                throw new ArgumentNullException($"{nameof(request.Note)} is missing");
            }
            return await _notesService.AddNewNote(request);
        }

        /// <summary>
        /// if a note needs to hit the shadow real, this is the endpoint that will do it.
        /// in order to delete a note, a note id is needed 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>true</returns>
        public async Task<bool> Delete(DeleteNoteRequest request)
        {
            if (request.NoteId == 0)
            {
                throw new ArgumentNullException($"{nameof(request.NoteId)} is missing");
            }
            return await _notesService.DeleteNote(request);
        }
    }
}
