using MediatR;

namespace Application.Commands.User;

public class UpdateUserCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UpdateUserCommand(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }   
}