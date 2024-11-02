using SupermarketWEB.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int? CategoryId { get; set; } // Hacer opcional si es necesario
    public Category Category { get; set; }
    public int? ProviderId { get; set; } // Hacer opcional si es necesario
    public Provider Provider { get; set; }

    // Agregar la propiedad PayModeId
 //   public int? PayModeId { get; set; }
 //   public PayMode PayMode { get; set; }
}
