namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class UserResponseForTokenStub
	{
		public static UserResponseForTokenTests ByDefault()
		{
			return new UserResponseForTokenTests(
				"049ce320-6a0d-46ed-94fa-cd5d1ac465c7",
				"example@example.com",
				"John",
				"Doe",
				"administrator"
			);
		}

		public static UserResponseForTokenTests FromValue(
			string userId,
			string email,
			string firstName,
			string lastName,
			string role
		)
		{
			return new UserResponseForTokenTests(userId, email, firstName, lastName, role);
		}
	}
}
