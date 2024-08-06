namespace MoviePulse.Api.Dtos;

public record class MovieDto (
    int Id, 
    string Title,
    string Genre,
    string Starring,
    DateOnly ReleaseDate,
    int Rating
);