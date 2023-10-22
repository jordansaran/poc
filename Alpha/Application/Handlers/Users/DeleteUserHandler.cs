using Application.Commands.Users;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Users;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(command.Id);
        if (user == null) return 0;
        _userRepository.Delete(user);
        var result = await _userRepository.Save();
        return result;
    }
}