using elearning.src.Shared.Domain;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.Hashing;

namespace elearning.src.IAM.User.Application.Command.SignUp
{
    public class SignUpUserCommandHandler : ICommandHandler
    {
        private readonly IHashing hashing;
        private readonly SignUpUserUseCase signUpUserUseCase;

        public SignUpUserCommandHandler(
            IHashing hashing,
            SignUpUserUseCase signUpUserUseCase
        )
        {
            this.hashing = hashing;
            this.signUpUserUseCase = signUpUserUseCase;
        }

        public void Handle(ICommand command)
        {
            SignUpUserCommand signUpUserCommand = command as SignUpUserCommand;
            HashedPassword hashedPassword = hashing.Hash(signUpUserCommand.password);

            UserId id = new UserId(signUpUserCommand.id);
            UserEmail email = new UserEmail(signUpUserCommand.email);
            UserFirstName firstName = new UserFirstName(signUpUserCommand.firstName);
            UserLastName lastName = new UserLastName(signUpUserCommand.lastName);
            UserHashedPassword password = new UserHashedPassword(
                hashedPassword.Value
            );
            UserRole role = new UserRole(signUpUserCommand.role);

            signUpUserUseCase.Invoke(id, email, firstName, lastName, password, role);
        }
    }
}
