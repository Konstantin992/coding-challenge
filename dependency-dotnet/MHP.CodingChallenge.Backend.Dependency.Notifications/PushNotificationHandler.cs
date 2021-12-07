using System;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.Extensions.Logging;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class PushNotificationHandler
    {
        public virtual void SendNotification(Inquiry.Inquiry inquiry)
        {
            Console.WriteLine(string.Format("sending notification inquiry: {0}", inquiry.ToString()));
        }
    }
}
