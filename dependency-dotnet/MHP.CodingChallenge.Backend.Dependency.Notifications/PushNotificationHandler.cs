using System;
using MediatR;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class PushNotificationHandler : IRequestHandler<SendNotificationCommand>
    {
        public Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            this.SendNotification(request.inquiry);
            return Task.FromResult(Unit.Value);
        }

        public virtual void SendNotification(Inquiry.Inquiry inquiry)
        {
            Console.WriteLine(string.Format("sending notification inquiry: {0}", inquiry.ToString()));
        }
    }
}
