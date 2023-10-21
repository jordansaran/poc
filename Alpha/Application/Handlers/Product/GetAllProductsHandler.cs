using Application.Queries.Product;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Product;

public class GetAllProductsHandler: IRequestHandler<GetProductListQuery, List<Domain.Product>>

{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Domain.Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Products.GetAll();
    }
}