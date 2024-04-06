

using MovieApp.ProfileApi.Domain.Entities.Base;

namespace MovieApp.ProfileApi.Domain.Entities;
public class Genre : Entity
{
    public string Name { get; set; }
    public IList<Movie> Movies { get; set; }
}
