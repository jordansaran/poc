using Domain;
using MediatR;

namespace Application.Commands.Users;

public class CreateUserCommand : IRequest<User>
{
    public string Name { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
}