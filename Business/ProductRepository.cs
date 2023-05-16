using Microsoft.Data.SqlClient;

namespace IoCDemo.Tests.Business
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int it)
        {
            var connection = new SqlConnection("Foo");
            connection.Open();
            connection.CreateCommand();
            // ...
            return new Product { Price = 42d };
        }
    }
}