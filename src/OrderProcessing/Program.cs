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
                ProductType = ProductType.Video,
                Amount = 100,
                Agent = new AgentDto
                {
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Email = "r.dravid@gmail.com"
                }

            };

            var orderStatus = OrderStatus.Pending;

            if(order.ProductType == ProductType.Physical)
            {
                orderStatus = new PhysicalProductProcessor(new ConsolePrinter()).Process(order);
            }

        }
    }
}
