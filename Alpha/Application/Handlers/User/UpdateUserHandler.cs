using Application.Commands.User;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetById(command.Id);
        if (user == null) return 0;
        _unitOfWork.Users.Update(user);
        user.Name = command.Name;
        user.Email = command.Email;
        var result = _unitOfWork.Save();
        return result;
    }
}