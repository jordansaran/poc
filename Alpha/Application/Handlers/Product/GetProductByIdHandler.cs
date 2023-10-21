using Application.Queries.Product;
using Data.Interfaces;
using MediatR;

namespace Application.Handlers.Product;

public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, Domain.Product>

{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Products.GetById(query.Id) ?? throw new InvalidOperationException();
    }
}
