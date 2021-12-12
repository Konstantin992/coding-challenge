using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Commands;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class EmailHandler : IRequestHandler<SendEmailCommand>
    {
        public Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            this.SendEmail(request.inquiry);
            return Task.FromResult(Unit.Value);
        }

        public virtual void SendEmail(Inquiry.Inquiry inquiry)
        {
            Console.WriteLine(string.Format("sending email for: {0}", inquiry.ToString()));
        }
    }
}
