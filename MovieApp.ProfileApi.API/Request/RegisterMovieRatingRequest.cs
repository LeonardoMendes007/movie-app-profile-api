﻿namespace MovieApp.ProfileApi.API.Request;

public class RegisterMovieRatingRequest
{
    public Guid MovieId { get; set; }
    public int Score { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;
}
