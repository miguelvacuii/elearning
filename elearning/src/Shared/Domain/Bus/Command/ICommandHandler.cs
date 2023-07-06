namespace elearning.src.Shared.Domain.Bus.Command {
    public interface ICommandHandler {
		void Handle(ICommand command);
	}
}
