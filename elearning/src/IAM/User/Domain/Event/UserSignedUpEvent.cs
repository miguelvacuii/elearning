using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.IAM.User.Domain.Event {

    public class UserSignedUpEvent : DomainEvent {

        public const string NAME = "user_signed_up";

        public UserSignedUpEvent(
            string aggregateId,
            Dictionary<string, string> body
        ) : base(aggregateId, body) { }

        public override string Name() {
            return NAME;
        }

        protected override Dictionary<string, string> Rules() {

            Dictionary<string, string> rules = new Dictionary<string, string> {
                { "email", "string" },
                { "first_name", "string" },
                { "last_name", "string" },
                { "role", "string" },
                { "created_at", "string" },
                { "updated_at", "string" },
            };

            return rules;
        }
    }
}
