using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessing.BusinessRule.Implementations;
using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Tests
{
    [TestClass]
    public class UpgradeMembershipProcessorTests
    {

        [TestMethod]
        public void UpgradeMembershipProcessor_Process_ShouldNotProcessTheOrder_WhenOrderIsForOtherThanMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            membershipManagerMock.Setup(a => a.Activate(It.IsAny<MembershipDto>()));

            var emailMock = new Mock<EmailHandler>();
            emailMock.Setup(a => a.SendEmail(It.IsAny<EmailDto>()));

            var processor = new UpgradeMembershipProcessor(membershipManagerMock.Object, emailMock.Object);

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
        public void UpgradeMembershipProcessor_Process_ShouldProcessTheOrder_WhenOrderIsForMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            membershipManagerMock.Setup(a => a.Activate(It.IsAny<MembershipDto>()));

            var emailMock = new Mock<EmailHandler>();
            emailMock.Setup(a => a.SendEmail(It.IsAny<EmailDto>()));

            var processor = new UpgradeMembershipProcessor(membershipManagerMock.Object, emailMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.UpgradeMembership,
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
        public void UpgradeMembershipProcessor_Process_ShouldUpgradeMembership_WhenOrderIsForMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            membershipManagerMock.Setup(a => a.Activate(It.IsAny<MembershipDto>()));

            var emailMock = new Mock<EmailHandler>();
            emailMock.Setup(a => a.SendEmail(It.IsAny<EmailDto>()));

            var processor = new UpgradeMembershipProcessor(membershipManagerMock.Object, emailMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.UpgradeMembership,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            membershipManagerMock.Verify(a => a.Upgrade(It.IsAny<MembershipDto>()), Times.Once);

        }

        [TestMethod]
        public void UpgradeMembershipProcessor_Process_ShouldSendEmailToOwner_WhenOrderIsForMembership()
        {
            var membershipManagerMock = new Mock<MembershipManager>();
            membershipManagerMock.Setup(a => a.Activate(It.IsAny<MembershipDto>()));

            var emailMock = new Mock<EmailHandler>();
            emailMock.Setup(a => a.SendEmail(It.IsAny<EmailDto>()));

            var processor = new UpgradeMembershipProcessor(membershipManagerMock.Object, emailMock.Object);

            var order = new OrderDto
            {
                ProductType = ProductType.UpgradeMembership,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }
            };

            var result = processor.Process(order);

            emailMock.Verify(a => a.SendEmail(It.IsAny<EmailDto>()), Times.Once);

        }
    }
}
