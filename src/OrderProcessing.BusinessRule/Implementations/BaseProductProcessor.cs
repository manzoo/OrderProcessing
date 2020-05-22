using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public abstract class BaseProductProcessor : IOrderProcessor
    {
        private IOrderProcessor Next;
        public virtual OrderStatus Process(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public IOrderProcessor SetNext(IOrderProcessor next)
        {
            Next = next;
            return Next;
        }
    }
}
