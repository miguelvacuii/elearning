using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.Shared.Infrastructure.Bus.Event
{
    public class DomainEventPublisherSync : IDomainEventPublisher {
        private readonly IEventBus eventBus;

        public DomainEventPublisherSync(IEventBus eventBus) {
            this.eventBus = eventBus;
        }

        public void Publish(DomainEvent domainEvent) {
            eventBus.Dispatch(domainEvent);
        }
    }
}
