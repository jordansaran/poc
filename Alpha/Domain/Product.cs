using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstracts;

namespace Domain;

[Table("Product")]
public class Product : GenericEntity
{
    public Product(string reference, string name, UnitType unit, decimal price, decimal costPrice, decimal purchasePrice)
    {
        Reference = reference;
        Name = name;
        Unit = unit;
        Price = price;
        CostPrice = costPrice;
        PurchasePrice = purchasePrice;
    }
 
    [Required]
    [Index("ProductReferenceIndex")]
    [MaxLength(16, ErrorMessage = "O tamanho máximo é {16} caracteres")]
    [MinLength(3, ErrorMessage = "O tamanho mínimo é {3} caracteres")]
    public string Reference { get; set; }
    
    [Required]
    [Index("ProductNameIndex")]
    [MaxLength(80, ErrorMessage = "O tamanho máximo é {1} caracteres")]
    [MinLength(3, ErrorMessage = "O tamanho mínimo é {3} caracteres")]
    public string Name { get; set; }
    
    [Required, EnumDataType(typeof(UnitType))]
    public UnitType Unit { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public decimal CostPrice { get; set; }
    
    [Required]
    public decimal PurchasePrice { get; set; }
    
}

public enum UnitType
{
    Caixa,
    Metro,
    Unidade,
    Conjunto
}