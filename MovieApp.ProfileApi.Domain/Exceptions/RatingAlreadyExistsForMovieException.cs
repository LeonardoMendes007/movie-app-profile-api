namespace MovieApp.ProfileApi.Domain.Exceptions;
public class RatingAlreadyExistsForMovieException : Exception
{
    public Guid Id { get; set; }
    public RatingAlreadyExistsForMovieException(Guid id) : base($"Rating already exists for the Movie with id = {id}.")
    {
        Id = id;
    }
}
