using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.CourseAdministration.Course.Domain.Service;
using elearning.src.Shared.Domain.Bus.Event;
using CourseAggregate = elearning.src.CourseAdministration.Course.Domain.Course;

namespace elearning.src.CourseAdministration.Course.Application.Command.Update
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