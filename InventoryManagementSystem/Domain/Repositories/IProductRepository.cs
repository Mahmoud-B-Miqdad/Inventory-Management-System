using InventoryManagementSystem.Domain.Models;
using System.Collections.Generic;

namespace InventoryManagementSystem.Domain.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void UpdateProduct(Product updatedProduct, string name);
        void DeleteProduct(string name);
    }
}
