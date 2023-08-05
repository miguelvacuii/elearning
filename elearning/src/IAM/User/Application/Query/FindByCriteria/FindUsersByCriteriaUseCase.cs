using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using System.Collections.Generic;
using elearning.src.Shared.Domain.Query.Criteria;

namespace elearning.src.IAM.User.Application.Query.FindByCriteria
{
    public class FindUsersByCriteriaUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly UserListResponseConverter userListResponseConverter;

        public FindUsersByCriteriaUseCase(
            IUserRepository userRepository,
            UserListResponseConverter userListResponseConverter
        ) {
            this.userRepository = userRepository;
            this.userListResponseConverter = userListResponseConverter;
        }

        public virtual UserListResponse Invoke(List<Criterion> criterion, List<Order> order, Limit limit, Offset offset)
        {
            Criteria criteria = Criteria.Create(criterion, order, limit, offset);
            List<UserAggregate> users = userRepository.Find(criteria);
            return userListResponseConverter.Convert(users);
        }
    }
}

