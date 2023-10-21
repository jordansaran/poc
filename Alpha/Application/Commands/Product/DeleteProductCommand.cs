using MediatR;

namespace AlphaWebAPI.Commands.Product;

public class DeleteProductCommand: IRequest<int>
{
    public int Id { get; set; }
}