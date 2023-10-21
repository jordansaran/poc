using Application.Queries.User;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class GetAllUsersHandler: IRequestHandler<GetUserListQuery, List<Domain.User>>

{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Domain.User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Users.GetAll();
    }
}