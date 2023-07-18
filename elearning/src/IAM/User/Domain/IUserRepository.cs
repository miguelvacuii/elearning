using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain
{
	public interface IUserRepository
	{
		void Add(User user);
		User Get(UUID id);
		User FindByEmail(UserEmail email);
		User FindByEmailAndPassword(UserEmail email, UserHashedPassword password);
		// TO-DO no funciona como una colección
		// Mas adelante será Find(Criteria criteria)
		// Para no violar OCP
	}
}
