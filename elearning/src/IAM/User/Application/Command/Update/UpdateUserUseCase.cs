using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Exception;
using elearning.src.Shared.Domain.Bus.Event;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IEventProvider eventProvider;

        public UpdateUserUseCase(
            IUserRepository userRepository,
            IEventProvider eventProvider
        )
        {
            this.userRepository = userRepository;
            this.eventProvider = eventProvider;
        }

        public virtual void Invoke(UserId userId, UserFirstName firstName, UserLastName lastName)
        {
            UserAggregate user = userRepository.Get(userId);
            if (user == null) {
                throw UserNotFoundException.FromId(userId);
            }
            if (user.firstName.Equals(firstName) && user.lastName.Equals(lastName)) {
                return;
            }
            user.Update(firstName, lastName);
            userRepository.Update(user);
            eventProvider.RecordEvents(user.ReleaseEvents());
        }
    }
}
