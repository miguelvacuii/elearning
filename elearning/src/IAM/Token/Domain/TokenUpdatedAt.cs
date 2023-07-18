using System;
using elearning.src.Shared.Domain;

namespace elearning.src.IAM.Token.Domain
{
	public class TokenUpdatedAt : DateTimeValueObject {
		public TokenUpdatedAt(DateTime value) : base(value) {}
	}
}
