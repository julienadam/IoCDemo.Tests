namespace IoCDemo.Tests.Business
{
    public interface IProductRepository
    {
        Product GetProductById(int it);
        void UpdateProduct(Product p, int id);
    }

}