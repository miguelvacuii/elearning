using elearning.src.Shared.Domain;
using System.Net.Mail;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain {
	public class UserEmail : StringValueObject {
		public UserEmail(string value) : base(value) {
			try {
				new MailAddress(value);
			}
			catch {
				throw InvalidAttributeException.FromValue("email", value);
			}
		}
	}
}
