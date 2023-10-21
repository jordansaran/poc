using Application.Commands.Product;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Product;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetById(command.Id);
        if (product == null) return 0;
        _unitOfWork.Products.Update(product);
        product.Name = command.Name;
        product.Reference = command.Reference;
        product.Price = command.Price;
        product.Unit = command.Unit;
        product.CostPrice = command.CostPrice;
        product.PurchasePrice = command.PurchasePrice;
        var result = _unitOfWork.Save();
        return result;
    }
}