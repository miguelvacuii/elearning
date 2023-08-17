using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Event
{
    public class EnrollmentCreatedEvent : DomainEvent
    {

        public const string NAME = "enrollment_created";

        public EnrollmentCreatedEvent(
            string aggregateId,
            Dictionary<string, string> body
        ) : base(aggregateId, body) { }

        public override string Name()
        {
            return NAME;
        }

        protected override Dictionary<string, string> Rules()
        {

            Dictionary<string, string> rules = new Dictionary<string, string> {
                { "progress", "string" },
                { "student_id", "string" },
                { "course_id", "string" },
                { "created_at", "string" },
                { "updated_at", "string" },
            };

            return rules;
        }
    }
}
