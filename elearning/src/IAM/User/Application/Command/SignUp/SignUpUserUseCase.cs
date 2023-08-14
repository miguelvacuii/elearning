using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Domain.Service;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.IAM.User.Application.Command.SignUp
{
    public class SignUpUserUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly UniqueUser uniqueUser;
        private readonly IEventProvider eventProvider;

        public SignUpUserUseCase(
            IUserRepository userRepository,
            UniqueUser uniqueUser,
            IEventProvider eventProvider
        ) {
            this.uniqueUser = uniqueUser;
            this.userRepository = userRepository;
            this.eventProvider = eventProvider;
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
            //uniqueUser.CheckUserEmailNotExists(user.email);
            uniqueUser.CheckUserNotExists(user);
            userRepository.Add(user);
            eventProvider.RecordEvents(user.ReleaseEvents());
        }
    }
}
