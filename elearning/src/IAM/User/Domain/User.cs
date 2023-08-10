using System;
using System.Collections.Generic;
using elearning.src.IAM.User.Domain.Event;
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

			user.Record(
   				new UserSignedUpEvent(
   					user.id.Value,
						new Dictionary<string, string>()
						{
							["email"] = user.email.Value,
							["first_name"] = user.firstName.Value,
							["last_name"] = user.lastName.Value,
							["role"] = user.role.Value,
							["created_at"] = user.createdAt.Value.ToString(),
							["updated_at"] = user.updatedAt.Value.ToString(),
						}
				 )
			);


			return user;
		}

		public void Update(UserFirstName newFirstName, UserLastName newLastName) {
			this.firstName = newFirstName;
			this.lastName = newLastName;
			this.updatedAt = new UserUpdatedAt(DateTime.Now);

			this.Record(
   				new UserUpdatedEvent(
   					this.id.Value,
						new Dictionary<string, string>()
						{
							["first_name"] = this.firstName.Value,
							["last_name"] = this.lastName.Value,
							["updated_at"] = this.updatedAt.Value.ToString(),
						}
					)
			);
        }
	}
}
