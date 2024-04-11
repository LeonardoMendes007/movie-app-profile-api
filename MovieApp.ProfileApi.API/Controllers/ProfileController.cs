using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Request;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses;
using System.Net;

namespace MovieApp.ProfileApi.API.Controllers;
[Route("api/profiles")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(IMediator mediator, ILogger<ProfileController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseBase<ProfileResponse>), 200)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var Profile = await _mediator.Send(new GetProfileByIdQuery(id));

        return Ok(ResponseBase<ProfileResponse>.ResponseBaseFactory(Profile, HttpStatusCode.OK));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseBase), 200)]
    [ProducesResponseType(typeof(ResponseBase), 409)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Post([FromBody] CreateProfileRequest createProfileRequest)
    {
        var createProfileCommand = new CreateProfileCommand
        {
            Id = createProfileRequest.Id,
            UserName = createProfileRequest.UserName
        };

        var id = await _mediator.Send(createProfileCommand);

        return CreatedAtAction(nameof(Get), new { id = id }, ResponseBase.ResponseBaseFactory(HttpStatusCode.Created));
        
    }

    [HttpPost("{id}/favorites")]
    [ProducesResponseType(typeof(ResponseBase), 204)]
    public async Task<IActionResult> RegisterFavorite([FromRoute] Guid id, [FromBody] RegisterFavoriteMovieRequest registerFavoriteMovieRequest)
    {
        var registerFavoriteMovieCommand = new RegisterFavoriteMovieCommand
        {
            ProfileId = id,
            MovieId = registerFavoriteMovieRequest.MovieId
        };

        await _mediator.Send(registerFavoriteMovieCommand);

        return StatusCode((int)HttpStatusCode.NoContent, ResponseBase.ResponseBaseFactory(HttpStatusCode.NoContent));
    }

    [HttpGet("{id}/favorites")]
    [ProducesResponseType(typeof(ResponseBase<PagedList<MovieResponse>>), 200)]
    public async Task<IActionResult> GetFavorites([FromRoute] Guid id, [FromQuery] GetFavoriteMoviesByProfileRequest getFavoriteMoviesByProfileRequest)
    {
        var getFavoriteMoviesByProfileQuery = new GetFavoriteMoviesByProfileQuery
        {
            ProfileId = id,
            GenreId = getFavoriteMoviesByProfileRequest.GenreId,
            Page = getFavoriteMoviesByProfileRequest.Page,
            PageSize = getFavoriteMoviesByProfileRequest.PageSize,
            SearchTerm = getFavoriteMoviesByProfileRequest.SearchTerm
        };

        var movies = await _mediator.Send(getFavoriteMoviesByProfileQuery);

        return Ok(ResponseBase<PagedList<MovieResponse>>.ResponseBaseFactory(movies, HttpStatusCode.OK));
    }

    [HttpPost("{id}/ratings")]
    [ProducesResponseType(typeof(ResponseBase), 204)]
    public async Task<IActionResult> RegisterRating([FromRoute] Guid id, [FromBody] RegisterMovieRatingRequest registerMovieRatingRequest)
    {
        var registerMovieRatingCommand = new RegisterMovieRatingCommand
        {
            ProfileId = id,
            MovieId = registerMovieRatingRequest.MovieId,
            Score = registerMovieRatingRequest.Score,
            Comment = registerMovieRatingRequest.Comment
        };

        await _mediator.Send(registerMovieRatingCommand);

        return NoContent();
    }

    [HttpGet("{id}/ratings")]
    [ProducesResponseType(typeof(ResponseBase<PagedList<RatingResponse>>), 200)]
    public async Task<IActionResult> GetRatings([FromRoute] Guid id, [FromQuery] GetRatingsByProfileRequest getProfileRatingsRequest)
    {
        var getRatingsByProfileQuery = new GetRatingsByProfileQuery
        {
             ProfileId = id,
             Page = getProfileRatingsRequest.Page,
             PageSize = getProfileRatingsRequest.PageSize
        };

        var ratings = await _mediator.Send(getRatingsByProfileQuery);

        return Ok(ResponseBase<PagedList<RatingResponse>>.ResponseBaseFactory(ratings, HttpStatusCode.OK));
    }
}
