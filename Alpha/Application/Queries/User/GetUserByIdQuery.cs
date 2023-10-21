using MediatR;

namespace Application.Queries.User;

public class GetUserByIdQuery : IRequest<Domain.User>
{
    public int Id { get; set; }

}