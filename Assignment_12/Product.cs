using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_12
{
    internal class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public decimal Price { get; set; }
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }
}
