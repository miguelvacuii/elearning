using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.StudentParticipation.Enrollment.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Application.Command
{
    public class CreateEnrollmentCommandHandler : ICommandHandler
    {
        private readonly CreateEnrollmentUseCase createEnrollmentUseCase;

        public CreateEnrollmentCommandHandler(
            CreateEnrollmentUseCase createEnrollmentUseCase
        )
        {
            this.createEnrollmentUseCase = createEnrollmentUseCase;
        }

        public void Handle(ICommand command)
        {
            CreateEnrollmentCommand createEnrollmentCommand = command as CreateEnrollmentCommand;

            EnrollmentId id = new EnrollmentId(createEnrollmentCommand.id);
            EnrollmentProgress progress = new EnrollmentProgress(createEnrollmentCommand.progress);
            EnrollmentCourseId courseId = new EnrollmentCourseId(createEnrollmentCommand.courseId);
            EnrollmentStudentId studentId = new EnrollmentStudentId(createEnrollmentCommand.studentId);

            createEnrollmentUseCase.Invoke(id, progress, courseId, studentId);
        }
    }
}