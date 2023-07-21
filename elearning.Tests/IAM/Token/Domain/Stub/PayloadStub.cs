using elearning.src.IAM.Token.Domain;

namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class PayloadStub
    {
		public static Payload ByDefault()
		{
			return new Payload(
				"049ce320-6a0d-46ed-94fa-cd5d1ac465c7",
				"example@example.com",
				"John",
				"Doe",
				"administrator"
			);
		}

		public static Payload FromValue(
			string userId,
			string email,
			string firstName,
			string lastName,
			string role
		){
			return new Payload(userId, email, firstName, lastName, role);
		}
	}
}
