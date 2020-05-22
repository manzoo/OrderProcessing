using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public class PhysicalProductProcessor
    {
        private readonly IPrinter _printer;

        public PhysicalProductProcessor(IPrinter printer)
        {
            _printer = printer;
        }
        public OrderStatus Process(OrderDto order)
        {
            _printer.Print("The product is booked");

            return OrderStatus.Success;
        }
    }
}
