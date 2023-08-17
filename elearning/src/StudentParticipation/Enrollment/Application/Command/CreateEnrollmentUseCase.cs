using elearning.src.CourseBackoffice.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.StudentParticipation.Enrollment.Domain;
using EnrollmentAggregate = elearning.src.StudentParticipation.Enrollment.Domain.Enrollment;

namespace elearning.src.StudentParticipation.Enrollment.Application.Command
{
    public class CreateEnrollmentUseCase
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly IEventProvider eventProvider;
        private readonly ISpecification enrollmentSpecificationFactory;

        public CreateEnrollmentUseCase(
            IEnrollmentRepository enrollmentRepository,
            IEventProvider eventProvider,
            ISpecification enrollmentSpecificationFactory
        )
        {
            this.enrollmentRepository = enrollmentRepository;
            this.eventProvider = eventProvider;
            this.enrollmentSpecificationFactory = enrollmentSpecificationFactory;
        }

        public virtual void Invoke(
            EnrollmentId id,
            EnrollmentProgress progress,
            EnrollmentCourseId courseId,
            EnrollmentStudentId studentId
        )
        {
            EnrollmentAggregate enrollment = EnrollmentAggregate.Create(
                id,
                progress,
                courseId,
                studentId,
                enrollmentSpecificationFactory.Create()
            ); ;
            enrollmentRepository.Add(enrollment);
            eventProvider.RecordEvents(enrollment.ReleaseEvents());
        }
    }
}