namespace MovieApp.ProfileApi.Domain.Exceptions;
public class MovieAlreadyExistsFavoriteException : Exception
{
    public Guid Id { get; set; }
    public MovieAlreadyExistsFavoriteException(Guid id) : base($"Movie already exists Favorite with id = {id}.")
    {
        Id = id;
    }
}
