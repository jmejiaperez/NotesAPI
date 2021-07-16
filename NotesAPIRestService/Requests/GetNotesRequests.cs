using ServiceStack;

namespace NotesAPIRestService.Requests
{
    [Route("/notes", Verbs = "GET", Notes = "Get all the notes that are stored.")]
    public class GetNotesRequests
    {
    }
}
