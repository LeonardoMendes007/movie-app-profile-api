namespace MovieApp.ProfileApi.Domain.Exceptions;
public class ProfileAlreadyExistsException : Exception
{
    public Guid Id { get; set; }
    public ProfileAlreadyExistsException(Guid id) : base($"Already exists Profile with id = {id}.")
    {
        Id = id;
    }
}
