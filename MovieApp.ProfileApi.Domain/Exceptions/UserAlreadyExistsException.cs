namespace MovieApp.ProfileApi.Domain.Exceptions;
public class UserAlreadyExistsException : Exception
{
    public Guid Id { get; set; }
    public UserAlreadyExistsException(Guid id) : base($"Already exists user with id = {id}.")
    {
        Id = id;
    }
}
