using System;
using System.Threading.Tasks;
using MediatR;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Commands;

namespace MHP.CodingChallenge.Backend.Dependency.Inquiry
{
    public class InquiryService
    {
        private readonly IMediator mediator;

        public InquiryService(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task CreateAsync(Inquiry inquiry)
        {
            Console.WriteLine(string.Format("User sent inquiry: {0}", inquiry.ToString()));

            await mediator.Send(new SendEmailCommand(inquiry));

            await mediator.Send(new SendNotificationCommand(inquiry));
        }
    }
}
