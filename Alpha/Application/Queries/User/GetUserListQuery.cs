using MediatR;

namespace Application.Queries.User;

public class GetUserListQuery : IRequest<List<Domain.User>>
{
    
}