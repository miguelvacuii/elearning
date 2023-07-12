using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.Shared.Domain
{
    public class AggregateRoot
    {
        private List<DomainEvent> events;

        public AggregateRoot()
        {
            this.events = new List<DomainEvent>();
        }

        protected void Record(DomainEvent domainEvent)
        {
            this.events.Add(domainEvent);
        }

        public List<DomainEvent> ReleaseEvents()
        {
            List<DomainEvent> events = this.events;
            RemoveEvents();
            return events;
        }

        private void RemoveEvents()
        {
            this.events = new List<DomainEvent>();
        }
    }
}
