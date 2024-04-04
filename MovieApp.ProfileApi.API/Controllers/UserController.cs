
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Rating;
using MovieApp.ProfileApi.Application.Responses.User;
using System;
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
    [ProducesResponseType(typeof(ResponseBase<UserResponse>), 200)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(new ResponseBase<UserResponse>(user, System.Net.HttpStatusCode.OK));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseBase), 200)]
    [ProducesResponseType(typeof(ResponseBase), 409)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    {
        try
        {
            var id = await _mediator.Send(createUserCommand);

            return CreatedAtAction(nameof(Get), new { id = id }, new ResponseBase(System.Net.HttpStatusCode.Created));
        }
        catch(ValidationException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred"
            };

            if (ex.Errors is not null)
            {
                problemDetails.Extensions["errors"] = ex.Errors;
            }

            return BadRequest(problemDetails);
        }
    }

    [HttpGet("{id}/favorites")]
    [ProducesResponseType(typeof(ResponseBase<MovieResponse>), 200)]
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
    [ProducesResponseType(typeof(ResponseBase<RatingResponse>), 200)]
    public async Task<IActionResult> GetRatings([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
    {
        var getUserRatingsQuery = new GetUserRatingsQuery()
        {
            Id = id,
            Take = take,
            Skip = skip
        };

        var ratings = await _mediator.Send(getUserRatingsQuery);

        return Ok(new ResponseBase<IEnumerable<RatingResponse>>(ratings, System.Net.HttpStatusCode.OK));
    }
}
