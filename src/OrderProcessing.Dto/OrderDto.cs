using System;

namespace OrderProcessing.Dto
{
    public class OrderDto
    {
        public ProductType ProductType { get; set; }

        public double Amount { get; set; }

        public AgentDto Agent { get; set; }
    }
}
