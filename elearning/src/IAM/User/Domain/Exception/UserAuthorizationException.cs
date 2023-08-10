using System.ComponentModel.DataAnnotations;

namespace elearning.src.IAM.User.Domain.Exception
{
    public class UserAuthorizationException : ValidationException
    {
		public UserAuthorizationException(string message) : base(message) { }

		public static UserAuthorizationException FromId(UserId id)
		{
			return new UserAuthorizationException(
				string.Format("Auth user id does not match with this id {0}", id.Value)
			);
		}
	}
}
