using MediatR;

namespace Application.Commands.Products;

public class DeleteProductCommand: IRequest<int>
{
    public int Id { get; set; }
}