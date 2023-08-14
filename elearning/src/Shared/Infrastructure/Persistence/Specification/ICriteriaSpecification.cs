using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.src.Shared.Infrastructure.Persistence.Specification
{
    public interface ICriteriaSpecification<T>
    {
        Criteria GetCriteria(T candidate);

        ICriteriaSpecification<T> And(ICriteriaSpecification<T> other);
    }
}
