namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class Student {
        public string id { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }

        public Student(
            string id,
            string email,
            string firstName,
            string lastName,
            string role
        ) {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}
