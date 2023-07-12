using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.Shared.Infrastructure.Bus.Event
{
	public interface IDomainEventPublisher
	{
		void Publish(DomainEvent domainEvent);
	}
}
