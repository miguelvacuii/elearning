using elearning.src.Shared.Infrastructure.Persistence.Repository;

namespace elearning.src.IAM.User.Domain
{
	public interface IUserRepository : IRepository<User>
	{
		User FindByEmail(UserEmail email);
		User FindByEmailAndPassword(UserEmail email, UserHashedPassword password);
	}
}
