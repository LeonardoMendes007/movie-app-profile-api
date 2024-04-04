namespace MovieApp.ProfileApi.Application.Responses.User;
public class UserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}
