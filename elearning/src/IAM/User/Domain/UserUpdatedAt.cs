using System;
using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain {
	public class UserUpdatedAt : DateTimeValueObject {
		public UserUpdatedAt(DateTime value) : base(value) {}
	}
}

