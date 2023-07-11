using System;
using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain
{
	public class User : AggregateRoot {

		public UserId id { get; private set; }
		public UserEmail email { get; private set; }
		public UserFirstName firstName { get; private set; }
		public UserLastName lastName { get; private set; }
		public UserHashedPassword password { get; private set; }
		public UserRole role { get; private set; }
		public UserCreatedAt createdAt { get; private set; }
		public UserUpdatedAt updatedAt { get; private set; }

		private User(
			UserId id,
			UserEmail email,
			UserFirstName firstName,
			UserLastName lastName,
			UserHashedPassword password,
			UserRole role,
			UserCreatedAt createdAt,
			UserUpdatedAt updatedAt
		) {
			this.id = id;
			this.email = email;
			this.firstName = firstName;
			this.lastName = lastName;
			this.password = password;
			this.role = role;
			this.createdAt = createdAt;
			this.updatedAt = updatedAt;
		}

		public static User SignUp(
			UserId id,
			UserEmail email,
			UserFirstName firstName,
			UserLastName lastName,
			UserHashedPassword password,
			UserRole role
		) {
			UserCreatedAt createdAt = new UserCreatedAt(DateTime.Now);
			UserUpdatedAt updatedAt = new UserUpdatedAt(DateTime.Now);

			User user = new User(
				id,
				email,
				firstName,
				lastName,
				password,
				role,
				createdAt,
				updatedAt
			);

			return user;
		}
	}
}
