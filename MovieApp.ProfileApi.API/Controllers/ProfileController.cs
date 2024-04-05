
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Rating;
using MovieApp.ProfileApi.Application.Responses.Profile;

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

        return Ok(new ResponseBase<ProfileResponse>(Profile, System.Net.HttpStatusCode.OK));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseBase), 200)]
    [ProducesResponseType(typeof(ResponseBase), 409)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Post([FromBody] CreateProfileCommand createProfileCommand)
    {
        try
        {
            var id = await _mediator.Send(createProfileCommand);

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
        var getProfileFavoritesQuery = new GetProfileFavoriteMoviesQuery()
        {
            Id = id,
            GenreId = genreId,
            SearchTerm = searchTerm,
            Take = take,
            Skip = skip
        };

        var movies = await _mediator.Send(getProfileFavoritesQuery);

        return Ok(new ResponseBase<IEnumerable<MovieResponse>>(movies, System.Net.HttpStatusCode.OK));
    }

    [HttpGet("{id}/ratings")]
    [ProducesResponseType(typeof(ResponseBase<RatingResponse>), 200)]
    public async Task<IActionResult> GetRatings([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
    {
        var getProfileRatingsQuery = new GetProfileRatingsQuery()
        {
            Id = id,
            Take = take,
            Skip = skip
        };

        var ratings = await _mediator.Send(getProfileRatingsQuery);

        return Ok(new ResponseBase<IEnumerable<RatingResponse>>(ratings, System.Net.HttpStatusCode.OK));
    }
}
