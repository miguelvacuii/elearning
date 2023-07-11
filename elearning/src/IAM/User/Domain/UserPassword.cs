using System.Text.RegularExpressions;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain
{
	public class UserPassword : StringValueObject
	{
		private const string PATTERN = "^[a-zA-Z0-9]{8,15}$";
		// TO-DO, la expresión regular no valida al menos dos números y dos mayúsculas

		public const int MIN_LENGTH = 8;
		public const int MAX_LENGTH = 15;

		public UserPassword(string value) : base(value)
		{
			if (!this.Is(value))
			{
				throw InvalidAttributeException.FromValue("password", value);
			}
		}

		private bool Is(string value)
		{
			Regex regex = new Regex(PATTERN);
			Match match = regex.Match(value);

			if (match.Success)
			{
				return true;
			}

			return false;
		}

		public static void Validate(string password, string repeatPassword)
		{
			if (password != repeatPassword)
			{
				throw InvalidAttributeException.FromText("Password are not equals");
			}
		}
	}
}


