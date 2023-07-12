using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Service.Mailer;

namespace elearning.src.IAM.User.Application.Event
{
    public class SendWelcomeEmailWhenUserSignedUpEventHandler : IEventHandler
    {
        private readonly IMailer mailer;

        public SendWelcomeEmailWhenUserSignedUpEventHandler(IMailer mailer)
        {
            this.mailer = mailer;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string, string> body = domainEvent.Body();

            mailer.Send(
                "hello@craftcode.com",
                body["email"],
                "Welcome email",
                "Gracias por registrarte. Recuerda que para iniciar sesión en nuestra aplicación debes usar tu email"
            );
        }
    }
}
