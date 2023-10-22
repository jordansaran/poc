using MediatR;

namespace Application.Commands.Users;

public class DeleteUserCommand: IRequest<int>
{
    public int Id { get; set; }
}