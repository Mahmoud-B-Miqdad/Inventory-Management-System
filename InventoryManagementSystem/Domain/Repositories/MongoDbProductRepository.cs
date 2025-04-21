using MongoDB.Driver;
using InventoryManagementSystem.Domain.Models;
using InventoryManagementSystem.Domain.Repositories;
using System.Configuration;

namespace InventoryManagementSystem.DataAccess
{
    public class MongoDbProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public MongoDbProductRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDBConnectionString"]?.ConnectionString;
            var client = new MongoClient(connectionString);  
            var database = client.GetDatabase("InventoryDB"); 
            _productCollection = database.GetCollection<Product>("products"); 
        }

        public void AddProduct(Product product)
        {
                _productCollection.InsertOne(product);
        }

        public List<Product> GetProducts()
        {
                return _productCollection.Find(product => true).ToList();
        }

        public void UpdateProduct(Product product, string originalName)
        {
                var filter = Builders<Product>.Filter.Eq(p => p.Name, originalName);
                var update = Builders<Product>.Update
                    .Set(p => p.Name, product.Name)
                    .Set(p => p.Price.ItemPrice, product.Price.ItemPrice)
                    .Set(p => p.Price.Currency, product.Price.Currency)
                    .Set(p => p.Quantity, product.Quantity);

                _productCollection.UpdateOne(filter, update);
        }

        public void DeleteProduct(string productName)
        {
                var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
                _productCollection.DeleteOne(filter);
        }
    }
}
