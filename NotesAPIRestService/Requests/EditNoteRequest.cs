using ServiceStack;
using System.Text.Json.Serialization;

namespace NotesAPIRestService.Requests
{
    /*
     * we want to give it multiple routes, so that the data is not lost
     */
    [Route("/notes", Verbs = "POST", Notes = "This route is here to route it to the post endpoint to catch the edge case")]
    [Route("/notes/{NoteId}", Verbs = "POST", Notes = "We will edit a note based on a note id and a note payload")]
    public class EditNoteRequest
    {
        [ApiMember(Name = "NoteId", IsRequired = true, ParameterType = "path", Description = "The id of the note that you want to edit. This is a numeric value starting from 1")]
        public int NoteId { get; set; }

        [JsonPropertyName("note")]
        [ApiMember(Name = "note", IsRequired = true, ParameterType = "formData", Description = "The new updated note message that is going to replace the one that is stored in the database")]
        public string Note { get; set; }

    }
}
