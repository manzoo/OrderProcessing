using System;

namespace OrderProcessing.Dto
{
    public class EmailDto
    {
        public string From { get; set; }
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
