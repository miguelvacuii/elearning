using elearning.src.CourseBackoffice.Domain;
using elearning.src.CourseBackoffice.Domain.Service;
using elearning.src.Shared.Domain.Bus.Event;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Command.Update
{
    public class UpdateCourseUseCase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IEventProvider eventProvider;
        private readonly CourseFinder courseFinder;

        public UpdateCourseUseCase (
            ICourseRepository courseRepository,
            IEventProvider eventProvider,
            CourseFinder courseFinder
        ) {
            this.courseRepository = courseRepository;
            this.eventProvider = eventProvider;
            this.courseFinder = courseFinder;
        }

        public virtual void Invoke(
            CourseId id,
            CourseName name,
            CourseDescription description
        ) {
            CourseAggregate course = courseFinder.FindById(id);
            course.Update(name, description);
            courseRepository.Update(course);
            eventProvider.RecordEvents(course.ReleaseEvents());
        }
    }
}