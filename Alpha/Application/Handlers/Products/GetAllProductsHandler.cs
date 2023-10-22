using Application.Queries.Products;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Products;

public class GetAllProductsHandler: IRequestHandler<GetProductListQuery, List<Product>>

{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAll();
    }
}