using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.IAM.Token.Domain.Event
{
    public class TokenCreatedEvent : DomainEvent
    {
        public const string NAME = "token_created";

        public TokenCreatedEvent(
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
                { "hash", "string" },
                { "user_id", "string" },
                { "created_at", "string" },
                { "updated_at", "string" },
            };

            return rules;
        }
    }
}