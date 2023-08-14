using elearning.src.Shared.Domain.Specification;

namespace elearning.src.IAM.User.Domain.Specification
{
    public class UserExistSpecification : SpecificationBase<User>
    {
        private readonly IUserRepository userRepository;

        public UserExistSpecification(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override bool IsSatisfiedBy(User candidate)
        {
            User user = userRepository.Get(candidate.id);
            return user != null;
        }
    }
}
