namespace elearning.src.Shared.Domain.Bus.Query {
    public interface IQueryBus {
        void Subscribe(IQueryHandler queryHandler);
        IResponse Ask(IQuery query);
    }
}
