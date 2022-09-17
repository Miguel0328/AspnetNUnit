using AspnetNUnit.Mocking;
using Moq;

namespace AspnetNUnit.Tests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        // CORRECT IMPLEMENTATION
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }

        // DO NOT ABUSE MOCKS (THIS IS AN EXAMPLE OF A BAD IMPLEMENTATION)
        // NEITHER MOCK NOR INTERFACE ARE REQUIRED
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscountMock()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }

    }
}