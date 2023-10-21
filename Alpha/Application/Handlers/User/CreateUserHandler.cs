using Application.Commands.User;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Domain.User>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Domain.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.User(name: request.Name, email: request.Email);
        await _unitOfWork.Users.Add(user);
        var result = _unitOfWork.Save();
        return (result > 0 ? user : null) ?? throw new InvalidOperationException();
    }
}