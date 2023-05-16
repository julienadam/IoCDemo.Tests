namespace IoCDemo.Tests.Business
{
    public class Calcul
    {
        IProductRepository repo;
        public Calcul(IProductRepository repo)
        {
            this.repo = repo;
        }

        public double? ComputeTax(int productId)
        {
            try
            {
                return repo.GetProductById(productId).Price * 19.2 / 100;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}