namespace MoviePulse.Api.Dtos;

public record class CreateMovieDto(
    string Title,
    string Genre,
    string Starring,
    DateOnly ReleaseDate,
    int Rating
);
