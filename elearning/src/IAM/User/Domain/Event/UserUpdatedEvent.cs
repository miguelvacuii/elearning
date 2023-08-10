using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.IAM.User.Domain.Event {

    public class UserUpdatedEvent : DomainEvent {

        public const string NAME = "user_updated";

        public UserUpdatedEvent(
            string aggregateId,
            Dictionary<string, string> body
        ) : base(aggregateId, body) { }

        public override string Name() {
            return NAME;
        }

        protected override Dictionary<string, string> Rules() {

            Dictionary<string, string> rules = new Dictionary<string, string> {
                { "first_name", "string" },
                { "last_name", "string" },
                { "updated_at", "string" },
            };

            return rules;
        }
    }
}
