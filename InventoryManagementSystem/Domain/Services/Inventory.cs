using InventoryManagementSystem.DataAccess;
using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Models;

namespace InventoryManagementSystem.Domain.Services
{
    public class Inventory
    {
        private List<Product> _products = new List<Product>();
        private readonly MSSQL_ProductRepository _repository;

        public Inventory(MSSQL_ProductRepository repository)
        {
            _repository = repository;
            LoadProducts();
        }

        private void LoadProducts()
        {
            _products = _repository.GetProducts();
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
            _repository.AddProduct(product);
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
            _repository.UpdateProduct(product,name);
            LoadProducts();
        }

        public void DeleteProduct(string name)
        {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                _repository.DeleteProduct(name);
                LoadProducts();
            }
        }

        public Product SearchProduct(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
