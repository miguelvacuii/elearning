using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain
{
	public interface IUserRepository
	{
		void Add(User user);
		User Get(UUID id);
		User FindByEmail(UserEmail email);
	}
}
