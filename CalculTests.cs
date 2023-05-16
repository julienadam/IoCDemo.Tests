using IoCDemo.Tests.Business;
using Moq;

namespace IoCDemo.Tests
{
    [TestFixture]
    public class CalculTests
    {
        [Test]
        public void Tax_is_correctly_calculated_for_existing_product()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo
                .Setup(x => x.GetProductById(1))
                .Returns(new Product { Price = 42.6 });

            Calcul c = new Calcul(mockRepo.Object);
            var result = c.ComputeTax(1);

            Assert.That(result, Is.EqualTo(8.1792));
            mockRepo.Verify(x => x.UpdateProduct(It.IsAny<Product>(), 1));
        }

        [Test]
        public void Tax_is_null_for_unknown_product()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo
                .Setup(x => x.GetProductById(1))
                .Throws(new ArgumentException());

            Calcul c = new Calcul(mockRepo.Object);
            var result = c.ComputeTax(1);

            Assert.That(result, Is.Null);
        }
    }
}