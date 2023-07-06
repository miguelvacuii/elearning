namespace elearning.src.Shared.Domain.Bus.Query {
    public interface IQueryHandler {
        IResponse Handle(IQuery query);
    }
}
