
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses;
using System.Net;

namespace MovieApp.ProfileApi.API.Controllers;
[Route("api/profile")]
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

        return Ok(new ResponseBase<ProfileResponse>(Profile, HttpStatusCode.OK));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseBase), 200)]
    [ProducesResponseType(typeof(ResponseBase), 409)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Post([FromBody] CreateProfileCommand createProfileCommand)
    {
        var id = await _mediator.Send(createProfileCommand);

        return CreatedAtAction(nameof(Get), new { id = id }, new ResponseBase(HttpStatusCode.Created));
        
    }

    [HttpPost("{id}/favorites")]
    [ProducesResponseType(typeof(ResponseBase), 204)]
    public async Task<IActionResult> GetFavorites([FromRoute] Guid id, [FromBody] RegisterFavoriteMovieCommand registerFavoriteMovieCommand)
    {
        registerFavoriteMovieCommand.SetProfileId(id); 

        await _mediator.Send(registerFavoriteMovieCommand);

        return StatusCode((int)HttpStatusCode.NoContent, new ResponseBase(HttpStatusCode.NoContent));
    }

    [HttpGet("{id}/favorites")]
    [ProducesResponseType(typeof(ResponseBase<PagedList<MovieResponse>>), 200)]
    public async Task<IActionResult> GetFavorites([FromRoute] Guid id, Guid? genreId = null, string searchTerm = "", int page = 1, int pageSize = 30)
    {
        var getProfileFavoritesQuery = new GetProfileFavoriteMoviesQuery()
        {
            Id = id,
            GenreId = genreId,
            SearchTerm = searchTerm,
            Page = page,
            PageSize = pageSize
        };

        var movies = await _mediator.Send(getProfileFavoritesQuery);

        return Ok(new ResponseBase<PagedList<MovieResponse>>(movies, HttpStatusCode.OK));
    }

    [HttpGet("{id}/ratings")]
    [ProducesResponseType(typeof(ResponseBase<PagedList<RatingResponse>>), 200)]
    public async Task<IActionResult> GetRatings([FromRoute] Guid id, int page = 0, int pageSize = 30)
    {
        var getProfileRatingsQuery = new GetProfileRatingsQuery()
        {
            Id = id,
            Page = page,
            PageSize = pageSize
        };

        var ratings = await _mediator.Send(getProfileRatingsQuery);

        return Ok(new ResponseBase<PagedList<RatingResponse>>(ratings, HttpStatusCode.OK));
    }
}
