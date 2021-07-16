using ServiceStack;

namespace NotesAPIRestService.Requests
{
    /*
     * we want to give it multiple routes, so that the data is not lost
     */
    [Route("/notes", Verbs = "DELETE", Notes = "This route is here to route it to the delete endpoint to catch the edge case")]
    [Route("/notes/{NoteId}", Verbs = "DELETE", Notes = "This endpoint is to delete a note based on a note id (1,2,3...)")]
    public class DeleteNoteRequest
    {
        [ApiMember(Name = "NoteId", IsRequired = true, ParameterType = "path", Description = "The id of the note that you want to delete. This is a numeric value starting from 1")]
        public int NoteId { get; set; }
    }
}
