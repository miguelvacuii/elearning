using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.src.Shared.Infrastructure.Persistence.Specification
{
    public abstract class CriteriaSpecificationBase<T> : ICriteriaSpecification<T>
    {
        public abstract Criteria GetCriteria(T candidate);

        public ICriteriaSpecification<T> And(ICriteriaSpecification<T> other)
        {
            return new CriteriaAndSpecification<T>(this, other);
        }
    }
}
