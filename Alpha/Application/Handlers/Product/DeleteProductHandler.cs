using AlphaWebAPI.Commands.Product;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
{
    
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetById(command.Id);
        if (product == null) return 0;
        _unitOfWork.Products.Delete(product);
        var result = _unitOfWork.Save();
        return result;
    }
}