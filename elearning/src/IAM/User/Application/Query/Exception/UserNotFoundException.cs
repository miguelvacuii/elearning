using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Application.Query.Exception
{
    public class UserNotFoundException : ResourceNotFoundException
    {
		public UserNotFoundException(string message) : base(message) { }

		public static UserNotFoundException FromId(UserId id)
		{
			return new UserNotFoundException(
				string.Format("Not found any user with this id {0}", id.Value)
			);
		}
	}
}
