using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Service.Mailer;

namespace elearning.src.CourseAdministration.Course.Application.Event
{
    public class SendEmailWhenCoursePublishedEventHandler : IEventHandler
    {
        private readonly IMailer mailer;

        public SendEmailWhenCoursePublishedEventHandler(IMailer mailer)
        {
            this.mailer = mailer;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string, string> body = domainEvent.Body();

            mailer.Send(
                "course_backoffice@craftcode.com",
                "admin@craftcode.com",
                "Curso publicado en la plataforma",
                "El curso con nombre " + body["name"] + " ha sido publicado"
            );
        }
    }
}
