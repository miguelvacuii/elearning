namespace elearning.src.CourseAdministration.Course.Domain
{
    public class Teacher
    {
        public string userId { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }

        public Teacher(string userId, string email, string firstName, string lastName, string role)
        {
            this.userId = userId;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}