﻿namespace SupermarketWEB.Models
{
    public class PayMode
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Mode { get; set; }
            public int Orders { get; set; } 
        
        public ICollection<Product>? Products { get; set; }
    }
}

