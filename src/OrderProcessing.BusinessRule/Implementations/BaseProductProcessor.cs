using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public abstract class BaseProductProcessor : IOrderProcessor
    {
        private IOrderProcessor _next;
        public virtual OrderStatus Process(OrderDto order)
        {
           if(_next != null)
            {
                return _next.Process(order);
            }

            return OrderStatus.Pending;
        }

        public IOrderProcessor SetNext(IOrderProcessor next)
        {
            _next = next;
            return _next;
        }
    }
}
