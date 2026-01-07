using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ProfileApi.Application.Commands;
public class DeleteFavoriteMovieCommand : IRequest
{
    public Guid ProfileId { get; set; }
    public Guid MovieId { get; set; }
}

