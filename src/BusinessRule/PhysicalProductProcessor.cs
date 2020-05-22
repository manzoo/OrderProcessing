using OrderProcessing.Dto;
using System;

namespace BusinessRule
{
    public class PhysicalProductProcessor
    {
        public OrderStatus Process(OrderDto order)
        {
            return OrderStatus.Success;
        }
    }
}
