using MediatR;

namespace Application.Commands.User;

public class CreateUserCommand : IRequest<Domain.User>
{
    public string Name { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
}