using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessing.BusinessRule.Implementations;
using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Tests
{
    [TestClass]
    public class BookProcessorTests
    {

        [TestMethod]
        public void BookProcessor_Process_ShouldNotProcessTheOrder_WhenOrderIsForOtherThanBook()
        {
            var printerMock = new Mock<IPrinter>();
            var paymentMock = new Mock<PaymentManager>();
            var processor = new BookProcessor(printerMock.Object, paymentMock.Object);

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
        public void BookProcessor_Process_ShouldProcessTheOrder_WhenOrderIsForBook()
        {
            var printerMock = new Mock<IPrinter>();
            var paymentMock = new Mock<PaymentManager>();
            var processor = new BookProcessor(printerMock.Object, paymentMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Book,
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
        public void BookProcessor_Process_ShouldPrint2Slips_WhenOrderIsValid()
        {
            var printerMock = new Mock<IPrinter>();
            printerMock.Setup(a => a.Print(It.IsAny<string>()));

            var paymentMock = new Mock<PaymentManager>();
            var processor = new BookProcessor(printerMock.Object, paymentMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Book,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            printerMock.Verify(a => a.Print(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void BookProcessor_Process_ShouldPayComissionToAgent_WhenOrderIsValid()
        {
            var printerMock = new Mock<IPrinter>();
            printerMock.Setup(a => a.Print(It.IsAny<string>()));

            var paymentMock = new Mock<PaymentManager>();
            paymentMock.Setup(a => a.Pay(It.IsAny<PaymentDto>()));
            var processor = new BookProcessor(printerMock.Object, paymentMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Book,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            paymentMock.Verify(a => a.Pay(It.IsAny<PaymentDto>()), Times.Once);
        }
    }
}
