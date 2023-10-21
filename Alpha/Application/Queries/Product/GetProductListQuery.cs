using MediatR;

namespace Application.Queries.Product;

public class GetProductListQuery : IRequest<List<Domain.Product>>
{
    
}