﻿using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Contracts
{
    public interface IMembershipManager
    {
        void Activate(MembershipDto membership);

        void upgrade(MembershipDto membership);
    }
}
