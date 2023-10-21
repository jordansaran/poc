using Application.Queries.User;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.User;

public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, Domain.User>

{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Domain.User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Users.GetAll();
    }

    public async Task<Domain.User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Users.GetById(query.Id) ?? throw new InvalidOperationException();
    }
}