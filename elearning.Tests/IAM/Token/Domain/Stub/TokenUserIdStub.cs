using elearning.src.IAM.Token.Domain;

namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class TokenUserIdStub
    {
		public static TokenUserId ByDefault()
		{
			return new TokenUserId("049ce320-6a0d-46ed-94fa-cd5d1ac465c7");
		}

		public static TokenUserId FromValue(string value)
		{
			return new TokenUserId(value);
		}
	}
}
