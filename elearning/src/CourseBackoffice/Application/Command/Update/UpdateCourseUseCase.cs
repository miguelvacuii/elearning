using elearning.src.CourseBackoffice.Domain;
using elearning.src.CourseBackoffice.Domain.Exception;
using elearning.src.CourseBackoffice.Infrastructure.Service.Course;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Domain.Exception;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Command.Update
{
    public class UpdateCourseUseCase
    {
        private readonly CourseAdapter courseAdapter;
        private readonly ICourseRepository courseRepository;
        private readonly IEventProvider eventProvider;
        private readonly OAuth oAuth;

        public UpdateCourseUseCase (
            CourseAdapter courseAdapter,
            ICourseRepository courseRepository,
            IEventProvider eventProvider,
            OAuth oAuth
        ) {
            this.courseAdapter = courseAdapter;
            this.courseRepository = courseRepository;
            this.eventProvider = eventProvider;
            this.oAuth = oAuth;
        }

        public virtual void Invoke(
            CourseId id,
            CourseName name,
            CourseDescription description
        ) {
            CourseAggregate course = courseRepository.Get(id);
            if (course == null)
            {
                throw CourseNotFoundException.FromId(id);
            }
            if (oAuth.User().id != course.teacherId.Value) {
                throw CourseUpdateException.FromUserId();
            }
            if (course.name.Equals(name) && course.description.Equals(name)) {
                return;
            }
            course.Update(name, description);
            courseRepository.Update(course);
            eventProvider.RecordEvents(course.ReleaseEvents());
        }
    }
}