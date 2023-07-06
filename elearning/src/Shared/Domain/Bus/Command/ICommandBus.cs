namespace elearning.src.Shared.Domain.Bus.Command {
    public interface ICommandBus {
        void Subscribe(ICommandHandler commandHandler);
        void Dispatch(ICommand command);
    }
}
