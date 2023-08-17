using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.StudentParticipation.Enrollment.Application.Command
{
    public class CreateEnrollmentCommand : ICommand
    {
        public string id { get; private set; }
        public int progress { get; private set; }
        public string studentId { get; private set; }
        public string courseId { get; private set; }

        public CreateEnrollmentCommand(
            string id,
            int progress,
            string studentId,
            string courseId
        )
        {
            this.id = id;
            this.progress = progress;
            this.studentId = studentId;
            this.courseId = courseId;
        }
    }
}
