using Application.Commands.Products;
using Data.Interfaces;
using Domain;
using MediatR;

namespace Application.Handlers.Products;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(reference: command.Reference, name: command.Name, unit: command.Unit,
        price: command.Price, costPrice: command.CostPrice, purchasePrice: command.PurchasePrice);
        product.CreatedAt = default;
        product.UpdatedAt = default;
        product.DeletedAt = null;

        await _productRepository.Add(product);
        
        var result = await _productRepository.Save();
        
        return (result > 0 ? product : null) ?? throw new InvalidOperationException();
    }
}