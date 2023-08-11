using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.CourseBackoffice.Domain.Event
{
    public class CourseCreatedEvent : DomainEvent
    {
        public const string NAME = "course_created";

        public CourseCreatedEvent(
            string aggregateId,
            Dictionary<string, string> body
        ) : base(aggregateId, body) { }

        public override string Name()
        {
            return NAME;
        }

        protected override Dictionary<string, string> Rules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>()
            {
                { "name", "string" },
                { "description", "string" },
                { "status", "string" },
                { "teacher_id", "string" },
            };

            return rules;
        }
    }
}