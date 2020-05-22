using OrderProcessing.BusinessRule.Contracts;
using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Implementations
{
    public class BookProcessor: BaseProductProcessor
    {
        private readonly IPrinter _printer;
        private readonly IPaymentManager _payment;

        public BookProcessor(IPrinter printer, IPaymentManager payment)
        {
            _printer = printer;
            _payment = payment;
        }

        public override OrderStatus Process(OrderDto order)
        {
            if(order.ProductType == ProductType.Book)
            {
                _printer.Print("This slip is for Shipping departmet");
                _printer.Print("This slip is for royalty department");

                _payment.Pay(new PaymentDto
                {
                    AccountId = order.Agent.AccountId,
                    Amount = 10
                });

                return OrderStatus.Success;
            }
            return base.Process(order);
        }
    }
}
