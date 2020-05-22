using OrderProcessing.Dto;
using System;

namespace OrderProcessing.BusinessRule.Contracts
{
    public class PaymentManager : IPaymentManager
    {
        public void Pay(PaymentDto payment)
        {
            Console.WriteLine($" Payment is made for the user :{payment.AccountId}  for amount : {payment.Amount}");
        }
    }
}
