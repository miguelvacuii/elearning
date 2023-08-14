using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Infrastructure.Persistence.Specification;

namespace elearning.src.IAM.User.Infrastructure.Persistence.Specification
{
    public class UserSpecificationFactory : IUserSpecificationFactory
    {
        public UserSpecificationFactory()
        {
        }

        public ICriteriaSpecification<Domain.User> CreateUniqueUser()
        {
            UserIdIsUniqueSpecification userIdIsUniqueSpecification = new UserIdIsUniqueSpecification();
            return userIdIsUniqueSpecification.And(new UserEmailIsUniqueSpecification());
        }
    }
}
