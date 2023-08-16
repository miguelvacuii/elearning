using System;
using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Service.Mailer;

namespace elearning.src.StudentParticipation.Enrollment.Application.Event
{
    public class SendEmailWhenEnrollmentCreated : IEventHandler
    {
        private readonly IMailer mailer;

        public SendEmailWhenEnrollmentCreated(IMailer mailer)
        {
            this.mailer = mailer;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string, string> body = domainEvent.Body();

            mailer.Send(
                "enrollment@craftcode.com",
                "admin@craftcode.com",
                "Nuevo curso creado en la plataforma por un profesor",
                string.Format("El estudiante con el id {0} se ha matriculado en el curso con el id {1}",
                    body["student_id"],
                    body["course_id"]
                )
            );
        }
    }
}
