using Funq;
using NotesAPIRestService;
using ServiceStack;
using ServiceStack.Api.OpenApi;
using ServiceStack.OrmLite;
using System.Data.SQLite;

namespace NotesAPI
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("notesapi", typeof(NotesRestService).Assembly) { }
        public override void Configure(Container container)
        {
            Plugins.Add(new CorsFeature());
            Plugins.Add(new OpenApiFeature
            {
                DisableAutoDtoInBodyParam = true,
                UseCamelCaseSchemaPropertyNames = true
            });

            GlobalRequestFilters.Add((req, res, requestDto) =>
            {
                // these filters are here so that we can modify the request and return a proper json object to the browser
                req.ResponseContentType = MimeTypes.Json;
                res.AddHeader(HttpHeaders.ContentType, "application/json");
                res.AddHeader("Access-Control-Allow-Origin", "*");
            });

            ServiceExceptionHandlers.Add((req, res, exception) =>
            {
                // if we get any exception, we are forcing a 400, and returning a message,
                req.Response.StatusCode = 400;

                return new { Error = exception.Message, Trace = exception.StackTrace };
            });
            // We need to create the sqlite database on runtime, so that we do not have to be creating it manually.
            SQLiteConnection.CreateFile("NotesDatabase.sqlite");
            var dbFactory = new OrmLiteConnectionFactory("NotesDatabase.sqlite", SqliteDialect.Provider);

            using var db = dbFactory.OpenDbConnection();
            // creating the table in the database
            db.CreateTable<NotesModel>();

            container.Register<INotesService>(new NotesService(dbFactory));

        }
    }

}
