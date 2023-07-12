using System.Collections.Generic;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.Shared.Domain.Bus.Event
{
    public abstract class DomainEvent {
        private string aggregateId;
        private Dictionary<string, string> body;

        public DomainEvent(
            string aggregateId,
            Dictionary<string, string> body
        ) {
            this.aggregateId = aggregateId;
            SetBody(body);
        }

        private void SetBody(Dictionary<string, string> body) {
            ValidateBody(body);
            this.body = body;
        }

        private void ValidateBody(Dictionary<string, string> body) {

            Dictionary<string, string> rules = Rules();

            if (body.Count != rules.Count) {
                throw new ValidationException(string.Format("Event body is incomplete or not valid"));
            }

            foreach (KeyValuePair<string, string> item in body) {

                if (string.IsNullOrEmpty(item.Value)) {
                    throw InvalidAttributeException.FromEmpty(item.Key);
                }

                bool rulesContainsKey = rules.ContainsKey(item.Key);

                if (!rules.ContainsKey(item.Key)) {
                    throw InvalidAttributeException.FromText(
                        string.Format("Event body property {0} not found in rules dictionary", item.Key)
                    );
                }


                string ruleValueType = rules[item.Key];
                string valueType = item.Value.GetType().ToString().ToLower();
                bool checkType = valueType.Contains(ruleValueType);

                if (!valueType.Contains(ruleValueType)) {
                    throw InvalidAttributeException.FromText(
                        string.Format("Event body property {0} has invalid type, must be {1}", item.Key, Rules()[item.Key])
                    );
                }
            }
        }

        public abstract string Name();

        protected abstract Dictionary<string, string> Rules();

        public string AggregateId() {
            return this.aggregateId;
        }

        public Dictionary<string, string> Body() {
            return this.body;
        }
    }
}
