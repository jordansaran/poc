using MediatR;

namespace Application.Commands.User;

public class DeleteUserCommand: IRequest<int>
{
    public int Id { get; set; }
}