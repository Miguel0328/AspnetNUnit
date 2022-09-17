using AspnetNUnit.Mocking;
using Moq;

namespace AspnetNUnit.Tests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            var result = controller.DeleteEmployee(1);

            storage.Verify(s => s.DeleteEmployee(1));

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

    }
}