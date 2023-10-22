using Domain;
using MediatR;

namespace Application.Queries.Products;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

}