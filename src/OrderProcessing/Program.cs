using OrderProcessing.BusinessRule.Implementations;
using OrderProcessing.Dto;
using System;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to order processing system !");

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

            var orderStatus = OrderStatus.Pending;

            Console.WriteLine($"Order is received for item { order.ProductType}");
            Console.WriteLine($"***************Processing starts****************");

            var processor = new PhysicalProductProcessor(new ConsolePrinter());
            processor.SetNext(new BookProcessor(new ConsolePrinter(), new PaymentManager()))
                .SetNext(new MembershipProcessor(new MembershipManager()))
                .SetNext(new UpgradeMembershipProcessor(new MembershipManager(), new EmailHandler()));

            orderStatus = processor.Process(order);

            Console.WriteLine($"The order status is : {orderStatus}");
            
            Console.WriteLine($"***************Processing ends****************");
        }
    }
}
