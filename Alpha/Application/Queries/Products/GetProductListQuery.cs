using Domain;
using MediatR;

namespace Application.Queries.Products;

public class GetProductListQuery : IRequest<List<Product>>
{
    
}