using ServiceStack.DataAnnotations;

namespace NotesAPIRestService
{
    public class NotesModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int NoteId { get; set; }
        public string Note { get; set; }
    }
}
