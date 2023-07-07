using elearning.src.IAM.User.Domain.Service.Exception;

namespace elearning.src.IAM.User.Domain.Service
{
	public class UniqueUser
	{
		private readonly IUserRepository userRepository;

		public UniqueUser(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public virtual void CheckUserEmailNotExists(UserEmail email)
		{
			User findUser = userRepository.FindByEmail(email);

			if (findUser is User)
			{
				throw UserFoundException.FromEmail(email);
			}
		}
	}
}
