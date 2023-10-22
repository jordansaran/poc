using Application.Commands.Users;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(command.Id);
        if (user == null) return 0;
        _userRepository.Update(user);
        user.Name = command.Name;
        user.Email = command.Email;
        var result = await _userRepository.Save();
        return result;
    }
}