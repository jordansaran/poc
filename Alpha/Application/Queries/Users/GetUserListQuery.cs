using Domain;
using MediatR;

namespace Application.Queries.Users;

public class GetUserListQuery : IRequest<List<User>>
{
    
}