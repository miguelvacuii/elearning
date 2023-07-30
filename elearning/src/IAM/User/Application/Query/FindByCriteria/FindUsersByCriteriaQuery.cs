using elearning.src.Shared.Infrastructure.Bus.Query.Criteria;
using Microsoft.AspNetCore.Http;

namespace elearning.src.IAM.User.Application.Query.FindByCriteria
{
    public class FindUsersByCriteriaQuery : CriteriaQueryBase
    {
        public FindUsersByCriteriaQuery(IQueryCollection query) : base(query) {}
    }
}