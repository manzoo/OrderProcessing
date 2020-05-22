using OrderProcessing.BusinessRule.Contracts;
using System;

namespace OrderProcessing.BusinessRule.Implementations
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}
