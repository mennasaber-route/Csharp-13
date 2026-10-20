using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_12
{
    internal class ProductRepository : IRepository<Product>
    {
        private List<Product> products = [];
        public void Create(Product entity)
        {
            Product product = new Product(entity.Id, entity.Name, entity.Price);
            products.Add(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return new Product(0, "Not Found", 0);
        }

        public void Update (int id, Product entity)
        {
            Product? ProductToUpdate = GetById(id);
            if (ProductToUpdate != null)
            {
                ProductToUpdate.Name = entity.Name;
                ProductToUpdate.Price = entity.Price;
            }
        }

        public void Delete(int id)
        {
            Product? ProductToDelete = GetById(id);
            products.Remove(ProductToDelete);
        }


    }
}
