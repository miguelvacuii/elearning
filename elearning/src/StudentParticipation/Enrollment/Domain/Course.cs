namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class Course
    {
        public string id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public string status { get; private set; }
        public string teacherId { get; private set; }

        public Course (
            string id,
            string name,
            string description,
            string status,
            string teacherId
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.status = status;
            this.teacherId = teacherId;
        }
    }
}