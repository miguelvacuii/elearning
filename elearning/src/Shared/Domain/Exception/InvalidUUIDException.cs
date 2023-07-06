namespace elearning.src.Shared.Domain.Exception
{
	public class InvalidUUIDException : InvalidAttributeException
	{
		public InvalidUUIDException(string message) : base(message) { }
	}
}