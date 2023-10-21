using Data.Context;
using Data.Interfaces;

namespace Data.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly DataContext _context;
        
    public IUserRepository Users { get; }
    public IProductRepository Products { get; }

    public UnitOfWork(DataContext context, IUserRepository userRepository, IProductRepository productRepository)
    {
        _context = context;
        Users = userRepository;
        Products = productRepository;
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}