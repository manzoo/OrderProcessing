﻿using OrderProcessing.Dto;
using System;

namespace OrderProcessing.BusinessRule.Contracts
{
    public class EmailHandler : IEmailHandler
    {
        public void SendEmail(EmailDto email)
        {
            Console.WriteLine($"Email from {email.From} sent to user {email.To} with subject: {email.Subject} and body : {email.Body}");
        }
    }
}
