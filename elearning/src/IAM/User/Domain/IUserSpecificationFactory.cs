using elearning.src.Shared.Infrastructure.Persistence.Specification;

namespace elearning.src.IAM.User.Domain
{
    public interface IUserSpecificationFactory
    {
        ICriteriaSpecification<User> CreateUniqueUser();
    }
}
