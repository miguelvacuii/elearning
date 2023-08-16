using System.Collections.Generic;
using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.src.Shared.Infrastructure.Persistence.Specification
{
    public class CriteriaAndSpecification<T> : CriteriaSpecificationBase<T>
    {
        private readonly ICriteriaSpecification<T> left;

        private readonly ICriteriaSpecification<T> right;

        public CriteriaAndSpecification(ICriteriaSpecification<T> left, ICriteriaSpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Criteria GetCriteria(T candidate)
        {
            List<Criterion> criterionList = new List<Criterion>();
            criterionList.AddRange(left.GetCriteria(candidate).criterion);
            criterionList.AddRange(right.GetCriteria(candidate).criterion);
            return Criteria.CreateForOne(criterionList);
        }
    }
}
