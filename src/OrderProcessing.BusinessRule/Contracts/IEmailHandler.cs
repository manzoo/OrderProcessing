using OrderProcessing.Dto;

namespace OrderProcessing.BusinessRule.Contracts
{
    public interface IEmailHandler
    {
        void SendEmail(EmailDto email);
    }
}
