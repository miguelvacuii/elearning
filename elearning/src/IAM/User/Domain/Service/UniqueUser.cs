using System.Collections.Generic;
using elearning.src.IAM.User.Domain.Service.Exception;
using elearning.src.Shared.Infrastructure.Persistence.Specification;

namespace elearning.src.IAM.User.Domain.Service
{
	public class UniqueUser
	{
		private readonly IUserRepository userRepository;
		private readonly IUserSpecificationFactory userSpecificationFactory;

		public UniqueUser(
			IUserRepository userRepository,
			IUserSpecificationFactory userSpecificationFactory
		) {
			this.userRepository = userRepository;
			this.userSpecificationFactory = userSpecificationFactory;
		}

		public virtual void CheckUserEmailNotExists(UserEmail email)
		{
			User findUser = userRepository.FindByEmail(email);

			if (findUser is User)
			{
				throw UserFoundException.FromEmail(email);
			}
		}

		public virtual void CheckUserNotExists(User user)
		{

			ICriteriaSpecification<User> criteriaSpecification = userSpecificationFactory.CreateUniqueUser();
			List<User> users = userRepository.Find(criteriaSpecification.GetCriteria(user));

			if (users.Count > 0)
			{
				throw UserFoundException.FromUser(user);
			}
		}
	}
}
