using Application.Commands.Products;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Products;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
{
    
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(command.Id);
        if (product == null) return 0;
        _productRepository.Delete(product);
        var result = await _productRepository.Save();
        return result;
    }
}