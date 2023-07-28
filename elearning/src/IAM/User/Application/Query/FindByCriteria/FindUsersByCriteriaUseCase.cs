using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using System.Collections.Generic;
using elearning.src.Shared.Domain.Query.Criteria;
using System;

namespace elearning.src.IAM.User.Application.Query.FindByCriteria
{
    public class FindUsersByCriteriaUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly UserResponseConverter userResponseConverter;

        public FindUsersByCriteriaUseCase(
            IUserRepository userRepository,
            UserResponseConverter userResponseConverter
        ) {
            this.userRepository = userRepository;
            this.userResponseConverter = userResponseConverter;
        }

        public virtual UserListResponse Invoke(List<Criterion> criterion, List<Order> order, Limit limit, Offset offset)
        {
            Criteria criteria = Criteria.Create(criterion, order, limit, offset);
            List<UserAggregate> users = userRepository.Find(criteria);
            return userResponseConverter.Convert(users);
        }

        public void Invoke(List<Criterion> criteria, List<Order> orders, Func<Limit> isAny1, Func<Offset> isAny2)
        {
            throw new NotImplementedException();
        }
    }
}

