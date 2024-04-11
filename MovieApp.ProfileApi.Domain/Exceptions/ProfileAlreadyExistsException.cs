namespace MovieApp.ProfileApi.Domain.Exceptions;
public class ProfileAlreadyExistsException : Exception
{
    public ProfileAlreadyExistsException(string message) : base(message)
    {
    }
}
