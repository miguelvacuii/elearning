using System;
using elearning.src.Shared.Domain;

namespace elearning.src.IAM.Token.Domain
{
	public class TokenCreatedAt : DateTimeValueObject {
		public TokenCreatedAt(DateTime value) : base(value) {}
	}
}
