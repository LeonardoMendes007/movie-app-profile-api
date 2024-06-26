﻿
using MovieApp.ProfileApi.Domain.Entities.Base;

namespace MovieApp.ProfileApi.Domain.Entities;
public class Movie : Entity
{
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ImageUrl { get; set; }
    public string PathM3U8File { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IList<Profile> ProfileRating { get; set; }
    public IList<Rating> Ratings { get; set; }
    public IList<Profile> FavoritesProfiles { get; set; }
    public IList<Genre> Genries { get; set; }
}
