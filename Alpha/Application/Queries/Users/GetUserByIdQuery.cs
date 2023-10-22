using Domain;
using MediatR;

namespace Application.Queries.Users;

public class GetUserByIdQuery : IRequest<User>
{
    public int Id { get; set; }

}