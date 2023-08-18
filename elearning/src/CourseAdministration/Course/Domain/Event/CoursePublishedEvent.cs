using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.CourseAdministration.Course.Domain.Event
{
    public class CoursePublishedEvent : DomainEvent
    {
        public const string NAME = "course_published";

        public CoursePublishedEvent(
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
                { "status", "string" },
            };

            return rules;
        }
    }
}