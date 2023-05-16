namespace IoCDemo.Tests.Business
{
    public class Calcul
    {
        private const double DefaultTaxRate = 19.2;
        private readonly IProductRepository repo;
        
        public Calcul(IProductRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public double? ComputeTax(int productId)
        {
            try
            {
                var originalProduct = repo.GetProductById(productId);
                var tax = originalProduct.Price * DefaultTaxRate / 100;
                Product updated = new Product {  Price = tax + originalProduct.Price };
                repo.UpdateProduct(updated, productId);
                return tax;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}