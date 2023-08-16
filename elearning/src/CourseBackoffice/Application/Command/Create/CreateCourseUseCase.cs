using elearning.src.CourseBackoffice.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Domain.Specification;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Command.Create
{
    public class CreateCourseUseCase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IEventProvider eventProvider;
        private readonly ISpecification<CourseAggregate> teacherExistSpecification;

        public CreateCourseUseCase (
            ICourseRepository courseRepository,
            IEventProvider eventProvider,
            ISpecification<CourseAggregate> teacherExistSpecification
        ) {
            this.courseRepository = courseRepository;
            this.eventProvider = eventProvider;
            this.teacherExistSpecification = teacherExistSpecification;
        }

        public virtual void Invoke(
            CourseId id,
            CourseName name,
            CourseDescription description,
            CourseTeacherId teacherId
        ) {
            CourseAggregate course = CourseAggregate.Create(
                id,
                name,
                description,
                teacherId,
                teacherExistSpecification
            );
            courseRepository.Add(course);
            eventProvider.RecordEvents(course.ReleaseEvents());
        }
    }
}
