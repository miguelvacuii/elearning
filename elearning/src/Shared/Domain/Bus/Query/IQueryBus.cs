using elearning.src.Shared.Infrastructure.Security.Authorization;

namespace elearning.src.Shared.Domain.Bus.Query {
    public interface IQueryBus {
        void Subscribe(IQueryHandler queryHandler);
        IResponse Ask(IQuery query);
        void Authorize(IAuthorization authorization);
    }
}
