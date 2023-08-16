using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain.Service.Exception
{
	public class UserFoundException : ValidationException
	{
		public UserFoundException(string message) : base(message) { }

		public static UserFoundException FromEmail(UserEmail email)
		{
			return new UserFoundException(
				string.Format("User is already registered with this email {0}", email.Value)
			);
		}

		public static UserFoundException FromUser(User user)
		{
			return new UserFoundException(
				string.Format(
					"User is already registered with this email {0} and id {1}",
					user.email.Value,
					user.id.Value
				)
			);
		}
	}
}
