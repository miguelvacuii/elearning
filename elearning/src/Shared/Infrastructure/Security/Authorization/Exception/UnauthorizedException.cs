using System.ComponentModel.DataAnnotations;
using elearning.src.IAM.User.Domain;

namespace elearning.src.Shared.Infrastructure.Security.Authorization.Exception
{
    public class UnauthorizedException : ValidationException
	{
		public UnauthorizedException(string message) : base(message) { }

		public static UnauthorizedException FromRole(UserRole role)
		{
			return new UnauthorizedException(
				string.Format("Unauthorized get resource from this role {0}", role.Value)
			);
		}
	}
}
