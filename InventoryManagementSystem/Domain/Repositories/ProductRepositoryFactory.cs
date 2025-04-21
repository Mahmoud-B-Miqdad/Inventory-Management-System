using InventoryManagementSystem.DataAccess;
using InventoryManagementSystem.Domain.Repositories;

public static class ProductRepositoryFactory
{
    public static IProductRepository CreateProductRepository(string databaseType)
    {
        return databaseType switch
        {
            "MongoDB" => new MongoDbProductRepository(),
            "MSSQL" => new MssqlProductRepository(),
            _ => throw new NotImplementedException($"Database type '{databaseType}' is not supported.")
        };
    }
}
