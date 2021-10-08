using System;

namespace ProductSQRS.API.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal LastPrice { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
