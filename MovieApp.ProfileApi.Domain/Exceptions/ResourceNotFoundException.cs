namespace MovieApp.ProfileApi.Domain.Exceptions;
public class ResourceNotFoundException : Exception
{
    public Guid Id { get; set; }

    public ResourceNotFoundException(Guid id) : base($"Resourse not found with id = {id}.")
    {
        Id = id;
    }
}
