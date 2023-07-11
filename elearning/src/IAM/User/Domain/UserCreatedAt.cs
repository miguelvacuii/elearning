using System;
using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain {
	public class UserCreatedAt : DateTimeValueObject {
		public UserCreatedAt(DateTime value) : base(value) {}
	}
}
