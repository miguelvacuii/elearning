using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Domain.Service;

namespace elearning.src.IAM.User.Application.Command.SignUp
{
    public class SignUpUserUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly UniqueUser uniqueUser;

        public SignUpUserUseCase(
            IUserRepository userRepository,
            UniqueUser uniqueUser
        ) {
            this.uniqueUser = uniqueUser;
            this.userRepository = userRepository;
        }

        public virtual void Invoke(
            UserId id,
            UserEmail email,
            UserFirstName firstName,
            UserLastName lastName,
            UserHashedPassword password,
            UserRole role
        ) {
            UserAggregate user = UserAggregate.SignUp(id, email, firstName, lastName, password, role);
            uniqueUser.CheckUserEmailNotExists(user.email);
            userRepository.Add(user);
        }
    }
}
