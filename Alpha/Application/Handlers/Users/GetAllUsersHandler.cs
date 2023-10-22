using Application.Queries.Users;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Users;

public class GetAllUsersHandler: IRequestHandler<GetUserListQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAll();
    }
}