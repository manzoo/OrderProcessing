using OrderProcessing.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessing.BusinessRule.Contracts
{
    public interface IPaymentManager
    {
        void Pay(PaymentDto payment);
    }
}
