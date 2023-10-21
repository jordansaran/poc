using Data.Context;
using Data.Interfaces;
using Domain;

namespace Data.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    
    public ProductRepository(DataContext context) : base(context)
    {

    }
    
}