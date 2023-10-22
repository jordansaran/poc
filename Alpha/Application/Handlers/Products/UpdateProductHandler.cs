using Application.Commands.Products;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Products;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
{
    
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(command.Id);
        if (product == null) return 0;
        _productRepository.Update(product);
        product.Name = command.Name;
        product.Reference = command.Reference;
        product.Price = command.Price;
        product.Unit = command.Unit;
        product.CostPrice = command.CostPrice;
        product.PurchasePrice = command.PurchasePrice;
        var result = await _productRepository.Save();
        return result;
    }
}