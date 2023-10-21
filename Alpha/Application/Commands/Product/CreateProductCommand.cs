using MediatR;

namespace Application.Commands.Product;

public class CreateProductCommand : IRequest<Domain.Product>
{
    
    public string Reference { get; set; }
    
    public string Name { get; set; }
    
    public Domain.Product.UnitType Unit { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal CostPrice { get; set; }
    
    public decimal PurchasePrice { get; set; }

    public CreateProductCommand(string reference, string name, Domain.Product.UnitType unit, decimal price, decimal costPrice, decimal purchasePrice)
    {
        Reference = reference;
        Name = name;
        Unit = unit;
        Price = price;
        CostPrice = costPrice;
        PurchasePrice = purchasePrice;
    }
}