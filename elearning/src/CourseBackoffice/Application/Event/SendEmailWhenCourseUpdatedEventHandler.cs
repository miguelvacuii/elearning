using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Service.Mailer;

namespace elearning.src.CourseBackoffice.Application.Event
{
    public class SendEmailWhenCourseUpdatedEventHandler : IEventHandler
    {
        private readonly IMailer mailer;

        public SendEmailWhenCourseUpdatedEventHandler(IMailer mailer)
        {
            this.mailer = mailer;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string, string> body = domainEvent.Body();

            mailer.Send(
                "course_backoffice@craftcode.com",
                "admin@craftcode.com",
                "Nuevo curso actualizado en la plataforma por un profesor",
                "Se ha actualziado el curso con nombre " + body["name"]
            );
        }
    }
}
