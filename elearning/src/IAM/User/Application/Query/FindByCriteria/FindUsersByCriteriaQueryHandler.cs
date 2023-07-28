using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Domain.Query.Criteria;
using elearning.src.Shared.Infrastructure.Bus.Query.Criteria;

namespace elearning.src.IAM.User.Application.Query.FindByCriteria
{
    public class FindUsersByCriteriaQueryHandler : IQueryHandler
    {

        private readonly FindUsersByCriteriaUseCase findUsersByCriteriaUseCase;

        public FindUsersByCriteriaQueryHandler(FindUsersByCriteriaUseCase findUsersByCriteriaUseCase)
        {
            this.findUsersByCriteriaUseCase = findUsersByCriteriaUseCase;
        }

        public IResponse Handle(IQuery query)
        {
            CriteriaQueryBase criteriaQueryBase = query as CriteriaQueryBase;
            List<Criterion> criterion = criteriaQueryBase.ToCriterion();
            List<Order> order = criteriaQueryBase.ToOrder();
            Limit limit = new Limit(criteriaQueryBase.limit);
            Offset offset = new Offset(criteriaQueryBase.offset);

            return findUsersByCriteriaUseCase.Invoke(criterion, order, limit, offset);
        }
    }
}