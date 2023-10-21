using Data.Context;
using Data.Interfaces;
using Domain;

namespace Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    
    public UserRepository(DataContext context) : base(context)
    {

    }
    
}