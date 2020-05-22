using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessing.BusinessRule.Implementations;
using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Tests
{
    [TestClass]
    public class PhysicalProductProcessorTests
    {

        [TestMethod]
        public void PhysicalProductProcessor_Process_ShouldNotProcessTheOrder_WhenOrderIsForOtherThanPhysicalProduct()
        {
            var processor = new PhysicalProductProcessor(new ConsolePrinter());

            var order = new OrderDto
            {
                ProductType = ProductType.Physical,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            Assert.AreEqual(OrderStatus.Pending, result);

        }
        [TestMethod]
        public void PhysicalProductProcessor_Process_ShouldProcessTheOrder_WhenOrderIsForPhysicalProduct()
        {
            var processor = new PhysicalProductProcessor(new ConsolePrinter());

            var order = new OrderDto
            {
                ProductType = ProductType.Physical,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            Assert.AreEqual(OrderStatus.Success, result);

        }

        [TestMethod]
        public void PhysicalProductProcessor_Process_ShouldPrintShippingSlip_WhenOrderIsValid()
        {
            var printerMock = new Mock<IPrinter>();
            printerMock.Setup(a => a.Print(It.IsAny<string>()));

            var processor = new PhysicalProductProcessor(printerMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Video,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            printerMock.Verify(a => a.Print(It.IsAny<string>()), Times.Once);
        }
    }
}
