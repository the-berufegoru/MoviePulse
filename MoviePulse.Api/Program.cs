using MoviePulse.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<MovieDto> movies = [
  new (1,
    "Who Am I",
    "Sci-fiction",
    "Friends",
    new DateOnly(2014, 5, 23),
    5),
 new (2,
    "Bumblebee",
    "Sci-fiction",
    "John Cena",
    new DateOnly(2018, 7, 3),
    9)
];

const string GetMovieEndpointName = "GetMovie";


// GET /movies
app.MapGet("movies", () => movies);

// GET /movies/id
app.MapGet("movies/{id}", (int id) => movies.Find(movie => movie.Id == id))
    .WithName(GetMovieEndpointName);

// POST /movies
app.MapPost("movies", (CreateMovieDto newMovie) =>
{
    MovieDto movie = new(
        movies.Count + 1,
        newMovie.Title,
        newMovie.Genre,
        newMovie.Starring,
        newMovie.ReleaseDate,
        newMovie.Rating
    );

    movies.Add(movie);

    return Results.CreatedAtRoute(GetMovieEndpointName, new { id = movie.Id }, movie);
});

// PUT /movies/id
app.MapPut("movies/{id}", (int id, UpdateMovieDto updatedMovie) =>
{
    var index = movies.FindIndex(movie => movie.Id == id);

    movies[index] = new MovieDto(
        id,
        updatedMovie.Title,
        updatedMovie.Genre,
        updatedMovie.Starring,
        updatedMovie.ReleaseDate,
        updatedMovie.Rating
    );

    return Results.NoContent();
});

// DELETE /movies/id
app.MapDelete("movies/{id}", (int id) => 
{
    movies.RemoveAll(movie => movie.Id == id);

    return Results.NoContent();
});

app.Run();
