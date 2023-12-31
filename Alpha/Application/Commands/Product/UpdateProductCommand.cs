using MediatR;

namespace Application.Commands.Product;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Reference { get; set; }
    
    public string Name { get; set; }
    
    public Domain.Product.UnitType Unit { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal CostPrice { get; set; }
    
    public decimal PurchasePrice { get; set; }

    public UpdateProductCommand(int id, string reference, string name, Domain.Product.UnitType unit, decimal price, decimal costPrice, decimal purchasePrice)
    {
        Id = id;
        Reference = reference;
        Name = name;
        Unit = unit;
        Price = price;
        CostPrice = costPrice;
        PurchasePrice = purchasePrice;
    }   
}