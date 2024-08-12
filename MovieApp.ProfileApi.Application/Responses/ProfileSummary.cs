namespace MovieApp.ProfileApi.Application.Responses;
public class ProfileSummary
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}
