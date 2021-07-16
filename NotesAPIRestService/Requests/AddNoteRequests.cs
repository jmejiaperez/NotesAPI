using ServiceStack;
using System.Text.Json.Serialization;

namespace NotesAPIRestService.Requests
{
    [Route("/notes", Verbs = "PUT", Notes = "This endpoint is to create a new note")]
    public class AddNoteRequests
    {
        [JsonPropertyName("note")]
        [ApiMember(Name = "note", IsRequired = true, ParameterType = "formData", Description = "Contents of the note that you want to save")]
        public string Note { get; set; }
    }
}
