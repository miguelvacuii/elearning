using elearning.src.CourseBackoffice.Domain;
using elearning.src.CourseBackoffice.Infrastructure.Service.Course;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Domain.Exception;
using elearning.src.Shared.Domain.Specification;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Command.Create
{
    public class CreateCourseUseCase
    {
        private readonly CourseAdapter courseAdapter;
        private readonly ICourseRepository courseRepository;
        private readonly IEventProvider eventProvider;
        private readonly ISpecification<CourseAggregate> teacherExistSpecification;

        public CreateCourseUseCase (
            CourseAdapter courseAdapter,
            ICourseRepository courseRepository,
            IEventProvider eventProvider,
            ISpecification<CourseAggregate> teacherExistSpecification
        ) {
            this.courseAdapter = courseAdapter;
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
            Teacher teacher = courseAdapter.FinTeacherById(teacherId.Value);
            if (teacher.role != AuthUser.ROLE_TEACHER) {
                throw InvalidAttributeException.FromText(
                    "This id not corresponding to an user with role teacher"
                );
            }
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