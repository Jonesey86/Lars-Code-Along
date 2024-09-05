class Movie
{
public string Title {get; set;}

public Movie(string title)
{
    Title = title;

}
}
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<List<Movie>>(); // Register the Movie list with the dependency Injection Container
        var app = builder.Build();



        // Get All Movies
        app.MapGet("/movies", (List<Movie> movies) => movies);

        // Create: Adds a new movie
        app.Map("/movies", (Movie? movie, List<Movie> movies ) => {

            if (movie == null)
            movies.Add(movie);
            {
            return Results.BadRequest();
            }
        });

        // Delete: delete a movie with Id
        app.MapDelete("/movies/{Id}", (int Id) => $"Delete movie with Id {Id}");

        // Update: Update a movie
        app.MapPut("/movies/{Id}", (int Id) => "Update movie with id:  {Id}");

        app.MapGet("/health", () =>
        {
            return "System healthy";
        });

        app.Run();
    }
}