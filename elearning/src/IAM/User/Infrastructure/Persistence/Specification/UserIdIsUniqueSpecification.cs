﻿using System.Collections.Generic;
using elearning.src.Shared.Domain.Query.Criteria;
using elearning.src.Shared.Infrastructure.Persistence.Specification;

namespace elearning.src.IAM.User.Infrastructure.Persistence.Specification
{
    public class UserIdIsUniqueSpecification : CriteriaSpecificationBase<Domain.User>
    {
        public override Criteria GetCriteria(Domain.User user)
        {
            Criterion criterion = Criterion.Create("id", user.id.Value);
            List<Criterion> criterionList = new List<Criterion>();
            criterionList.Add(criterion);
            return Criteria.CreateForOne(criterionList);
        }
    }
}
