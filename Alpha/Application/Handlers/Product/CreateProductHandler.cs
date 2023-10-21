using Application.Commands.Product;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Product;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Domain.Product>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Domain.Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Domain.Product(reference: command.Reference, name: command.Name, unit: command.Unit,
            price: command.Price, costPrice: command.CostPrice, purchasePrice: command.PurchasePrice);
        product.CreatedAt = default;
        product.UpdatedAt = default;
        product.DeletedAt = null;
        await _unitOfWork.Products.Add(product);
        var result = _unitOfWork.Save();
        return (result > 0 ? product : null) ?? throw new InvalidOperationException();
    }
}