using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Contracts
{
    public interface IOrderProcessor
    {
        IOrderProcessor SetNext(IOrderProcessor next);
        OrderStatus Process(OrderDto order);
    }
}
