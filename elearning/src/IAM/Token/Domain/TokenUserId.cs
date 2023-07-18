using elearning.src.Shared.Domain;

namespace elearning.src.IAM.Token.Domain
{
	public class TokenUserId : UUID {
		public TokenUserId(string value) : base(value) {}
	}
}
