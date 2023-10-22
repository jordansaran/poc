using Application.Queries.Users;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Users;

public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return await _userRepository.GetById(query.Id) ?? throw new InvalidOperationException();
    }
}