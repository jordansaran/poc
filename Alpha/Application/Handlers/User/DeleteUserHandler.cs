using Application.Commands.User;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetById(command.Id);
        if (user == null) return 0;
        _unitOfWork.Users.Delete(user);
        var result = _unitOfWork.Save();
        return result;
    }
}