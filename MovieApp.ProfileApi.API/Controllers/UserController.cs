using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.User;
using System.Net;

namespace MovieApp.ProfileApi.API.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(new ResponseBase<UserResponse>(user, System.Net.HttpStatusCode.OK));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    {
        try
        {
            var id = await _mediator.Send(createUserCommand);

            return CreatedAtAction(nameof(Get), new { id = id }, new ResponseBase(System.Net.HttpStatusCode.Created));
        }
        catch(ValidationException ex)
        {
            return BadRequest(new ResponseBase<IDictionary<string, string[]>>(ex.Errors, HttpStatusCode.BadRequest, "Validation error"));
        }
    }

    [HttpGet("{id}/favorites")]
    public async Task<IActionResult> GetFavorites([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
    {
        var getUserFavoritesQuery = new GetUserFavoriteMoviesQuery()
        {
            Id = id,
            GenreId = genreId,
            SearchTerm = searchTerm,
            Take = take,
            Skip = skip
        };

        var movies = await _mediator.Send(getUserFavoritesQuery);

        return Ok(new ResponseBase<IEnumerable<MovieResponse>>(movies, System.Net.HttpStatusCode.OK));
    }

    [HttpGet("{id}/ratings")]
    public async Task<IActionResult> GetRatings([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
    {
        var getUserFavoritesQuery = new GetUserFavoriteMoviesQuery()
        {
            Id = id,
            GenreId = genreId,
            SearchTerm = searchTerm,
            Take = take,
            Skip = skip
        };

        var movies = await _mediator.Send(getUserFavoritesQuery);

        return Ok(new ResponseBase<IEnumerable<MovieResponse>>(movies, System.Net.HttpStatusCode.OK));
    }
}
