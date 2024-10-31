namespace SupermarketWEB.Models
{
    public class Provider
    {
        public int Id { get; set; } // Llave primaria
        public string Name { get; set; }
        public string? ContactInfo { get; set; }
        public ICollection<Product>? Products { get; set; } // Propiedad de navegación
    }
}
