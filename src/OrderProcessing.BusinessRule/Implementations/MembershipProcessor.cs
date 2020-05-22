using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public class MembershipProcessor: BaseProductProcessor
    {
        private readonly MembershipManager _membershipManager;

        public MembershipProcessor(MembershipManager membershipManager)
        {
            _membershipManager = membershipManager;
        }

        public override OrderStatus Process(OrderDto order)
        {
            if (order.ProductType == ProductType.Membership)
            {
                _membershipManager.Activate(new MembershipDto
                {
                    AccountId = 100, // read it from user
                    Email = "Some@email.com" // read it from order
                });

                return OrderStatus.Success;
            }

            return base.Process(order);
        }
    }
}
