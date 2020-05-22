using OrderProcessing.Dto;
using System;

namespace OrderProcessing.BusinessRule.Contracts
{
    public class MembershipManager : IMembershipManager
    {
        public void Activate(MembershipDto membership)
        {
            Console.WriteLine($"Membership activated for user {membership.Email}");
        }

        public void Upgrade(MembershipDto membership)
        {
            Console.WriteLine($"Membership of user {membership.Email} upgraded to : {membership.Type}");
        }
    }
}
