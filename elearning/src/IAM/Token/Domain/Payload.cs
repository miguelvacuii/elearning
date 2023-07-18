namespace elearning.src.IAM.Token.Domain
{
    public class Payload
    {
        public string userId { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }

        public Payload(string userId, string email, string firstName, string lastName, string role)
        {
            this.userId = userId;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}
