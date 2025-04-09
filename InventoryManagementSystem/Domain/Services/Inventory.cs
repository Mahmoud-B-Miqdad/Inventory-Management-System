using InventoryManagementSystem.DataAccess;
using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Models;
using InventoryManagementSystem.Domain.Repositories;

namespace InventoryManagementSystem.Domain.Services
{
    public class Inventory
    {
        private List<Product> _products = new List<Product>();
        private readonly IProductRepository _productRepository;

        public Inventory(IProductRepository repository)
        {
            _productRepository = repository;
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = _productRepository.GetProducts();
        }

        public void PrintProduct(Product product)
        {
            Console.WriteLine($"\n********************************\nName: {product.Name}\nPrice: {product.Price:C}\nQuantity: {product.Quantity}" +
                    $"\n********************************");
        }

        public Product FindProductByName(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddProduct(string name, Price price, int quantity)
        {
            Product product = new Product(name, price, quantity);
            _productRepository.AddProduct(product);
            LoadProducts();
        }

        public List<Product> ViewProducts()
        {
            if (_products.Count == 0)
            {
                return null;
            }
            return _products;
        }

        public void EditProduct(string name, string newName, Price newPrice, int newQuantity)
        {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(newName)) product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;
            _productRepository.UpdateProduct(product,name);
            LoadProducts();
        }

        public void DeleteProduct(string name)
        {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                _productRepository.DeleteProduct(name);
                LoadProducts();
            }
        }

        public Product SearchProduct(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
