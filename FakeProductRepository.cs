using IoCDemo.Tests.Business;

namespace IoCDemo.Tests
{
    public class FakeProductRepository : IProductRepository
    {
        Product IProductRepository.GetProductById(int id)
        {
            if (id == 1)
            {
                return new Product { Price = 42.6 };
            }
            throw new Exception();
        }
    }
}