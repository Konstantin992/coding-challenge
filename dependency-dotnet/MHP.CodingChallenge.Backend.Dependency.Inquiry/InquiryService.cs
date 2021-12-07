using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MHP.CodingChallenge.Backend.Dependency.Inquiry
{
    public class InquiryService
    {
        public void Create(Inquiry inquiry)
        {
            Console.WriteLine(string.Format("User sent inquiry: {0}", inquiry.ToString()));
        }
    }
}
