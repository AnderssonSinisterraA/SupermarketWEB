using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; } // Corregido de Stork a Stock
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
