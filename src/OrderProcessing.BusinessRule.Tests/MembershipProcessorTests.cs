using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessing.BusinessRule.Implementations;
using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Tests
{
    [TestClass]
    public class MembershipProcessorTests
    {

        [TestMethod]
        public void MembershipProcessor_Process_ShouldNotProcessTheOrder_WhenOrderIsForOtherThanMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            var processor = new MembershipProcessor(membershipManagerMock.Object);

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
        public void MembershipProcessor_Process_ShouldProcessTheOrder_WhenOrderIsForMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            var processor = new MembershipProcessor(membershipManagerMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Membership,
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
        public void MembershipProcessor_Process_ShouldActivateMembership_WhenOrderIsForMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            membershipManagerMock.Setup(a => a.Activate(It.IsAny<MembershipDto>()));

            var processor = new MembershipProcessor(membershipManagerMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.Membership,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            membershipManagerMock.Verify(a => a.Activate(It.IsAny<MembershipDto>()), Times.Once);

        }
    }
}
