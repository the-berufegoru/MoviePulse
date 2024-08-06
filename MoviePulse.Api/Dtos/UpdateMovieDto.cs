namespace MoviePulse.Api.Dtos;

public record class UpdateMovieDto
(
    string Title,
    string Genre,
    string Starring,
    DateOnly ReleaseDate,
    int Rating
);