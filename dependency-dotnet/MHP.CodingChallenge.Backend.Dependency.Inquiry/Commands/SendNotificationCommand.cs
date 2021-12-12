using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.CodingChallenge.Backend.Dependency.Inquiry.Commands
{
    public class SendNotificationCommand : IRequest
    {
        public SendNotificationCommand(Inquiry inquiry)
        {
            this.inquiry = inquiry;
        }

        public Inquiry inquiry { get; set; }
    }
}
