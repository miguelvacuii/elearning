using elearning.src.IAM.User.Domain.Exception;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Domain.Service
{
    public class UserFinder
    {
        private readonly IUserRepository userRepository;

        public UserFinder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserAggregate FindById(UserId id)
        {
            UserAggregate User = userRepository.Get(id);
            if (User == null)
            {
                throw UserNotFoundException.FromId(id);
            }
            return User;
        }
    }
}
