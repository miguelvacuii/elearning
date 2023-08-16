using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Service;
using elearning.src.Shared.Domain.Bus.Event;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IEventProvider eventProvider;
        private readonly UserFinder userFinder;

        public UpdateUserUseCase(
            IUserRepository userRepository,
            IEventProvider eventProvider,
            UserFinder userFinder
        )
        {
            this.userRepository = userRepository;
            this.eventProvider = eventProvider;
            this.userFinder = userFinder;
        }

        public virtual void Invoke(UserId userId, UserFirstName firstName, UserLastName lastName)
        {
            UserAggregate user = userFinder.FindById(userId);
            user.Update(firstName, lastName);
            userRepository.Update(user);
            eventProvider.RecordEvents(user.ReleaseEvents());
        }
    }
}
