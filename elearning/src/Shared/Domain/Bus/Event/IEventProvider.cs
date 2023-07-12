using System.Collections.Generic;

namespace elearning.src.Shared.Domain.Bus.Event {
    public interface IEventProvider {
        void RecordEvents(List<DomainEvent> domainEvnts);
        List<DomainEvent> ReleaseEvents();
    }
}
