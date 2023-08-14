using elearning.src.Shared.Domain.Specification;

namespace elearning.src.IAM.User.Domain.Specification
{
    public class EmailExistSpecification : SpecificationBase<User>
    {
        private readonly IUserRepository userRepository;

        public EmailExistSpecification(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override bool IsSatisfiedBy(User candidate)
        {
            User user = userRepository.FindByEmail(candidate.email);
            return user == null;
        }
    }
}
