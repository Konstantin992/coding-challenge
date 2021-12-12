using Xunit;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.Extensions.DependencyInjection;
using MHP.CodingChallenge.Backend.Dependency.Notifications;
using Moq;
using MediatR;
using NSubstitute;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Commands;

namespace MHP.CodingChallenge.Backend.Dependency.Test
{
    public class InquiryTest
    {
        // This test displays the decoupling of dependencies with IoC, by making sure that the
        // related commands within the service get successfully dispatched. In this case the package Mediator will resolve
        // the corresponding handlers and then execute domain logic. 
        // To persue the SOLID principle these handlers should receive their own unit tests.
        // I'm currently unsure if it is possible to implement such integration test when using Mediator,
        // because I am unaware of a possibility to mock the handlers and with thus verify, that the domain logic was called.
        [Fact]
        public void TestInquiryHandlers()
        {
            // given
            Inquiry.Inquiry inquiry = new Inquiry.Inquiry();
            inquiry.Username = "TestUser";
            inquiry.Recipient = "service@example.com";
            inquiry.Text = "Can I haz cheezburger?";

            var mediator = Substitute.For<IMediator>();
            var inquiryService = new InquiryService(mediator);

            var services = new ServiceCollection()
                .AddLogging()
                .AddSingleton(inquiryService)
                .AddMediatR(typeof(EmailHandler))
                .AddMediatR(typeof(PushNotificationHandler));

            inquiryService = services
                .BuildServiceProvider()
                .GetRequiredService<InquiryService>();

            // when
            inquiryService.CreateAsync(inquiry).GetAwaiter().GetResult();

            // then
            mediator.Received().Send(Arg.Is<SendEmailCommand>(c => c.inquiry == inquiry));
            mediator.Received().Send(Arg.Is<SendNotificationCommand>(c => c.inquiry == inquiry));
        }
    }
}
