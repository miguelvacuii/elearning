namespace elearning.src.Shared.Domain.Bus.Event {
    public interface IEventHandler {
        void Handle(DomainEvent domainEvent);
    }
}
