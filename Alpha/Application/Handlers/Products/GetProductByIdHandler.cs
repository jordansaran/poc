using Application.Queries.Products;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Products;

public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, Product>

{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        return await _productRepository.GetById(query.Id) ?? throw new InvalidOperationException();
    }
}
