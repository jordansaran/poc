using MediatR;

namespace Application.Queries.Product;

public class GetProductByIdQuery : IRequest<Domain.Product>
{
    public int Id { get; set; }

}