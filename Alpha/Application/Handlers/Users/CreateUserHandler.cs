using Application.Commands.Users;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Users;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(name: request.Name, email: request.Email);
        await _userRepository.Add(user);
        var result = await _userRepository.Save();
        return (result > 0 ? user : null) ?? throw new InvalidOperationException();
    }
}