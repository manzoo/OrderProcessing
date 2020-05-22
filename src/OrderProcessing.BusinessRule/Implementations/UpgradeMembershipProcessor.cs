using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public class UpgradeMembershipProcessor: BaseProductProcessor
    {
        private readonly MembershipManager _membershipManager;
        private readonly EmailHandler _emailHandler;

        public UpgradeMembershipProcessor(MembershipManager membershipManager, EmailHandler emailHandler)
        {
            _membershipManager = membershipManager;
            _emailHandler = emailHandler;
        }

        public override OrderStatus Process(OrderDto order)
        {
            if (order.ProductType == ProductType.UpgradeMembership)
            {
                _membershipManager.Upgrade(new MembershipDto
                {
                    AccountId = 100, // read it from user
                    Email = "Some@email.com" // read it from order
                });

                // end an email to user

                _emailHandler.SendEmail(new EmailDto
                {
                    From = "noreaply@abcd.com",
                    To = "Some@email.com", // read it from order
                    Subject = "Your membership upgraded",
                    Body = "Your membership upgraded"
                });

                return OrderStatus.Success;
            }

            return base.Process(order);
        }
    }
}
