using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("User")]
public class User
{
    public User()
    {
    }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    [Key]
    [System.Text.Json.Serialization.JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(80, ErrorMessage = "O tamanho máximo é {1} caracteres")]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(80, ErrorMessage = "O tamanho máximo é {1} caracteres")]
    public string Email { get; set; }
}