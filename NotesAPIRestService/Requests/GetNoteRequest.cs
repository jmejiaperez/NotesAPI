using ServiceStack;

namespace NotesAPIRestService.Requests
{
    [Route("/notes/{NoteId}", Verbs = "GET", Notes = "We will get a note based on a note id")]
    public class GetNoteRequest
    {
        [ApiMember(Name = "NoteId", IsRequired = true, ParameterType = "path", Description = "The id of the note that you want to get. This is a numeric value starting from 1")]
        public int NoteId { get; set; }
    }
}
