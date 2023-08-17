using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Query.Response
{
    public class CourseResponseConverter {
        public virtual CourseResponse Convert(CourseAggregate course) {
            return new CourseResponse(
                course.id.Value,
                course.name.Value,
                course.description.Value,
                course.status.Value,
                course.teacherId.Value
            );
        }
    }
}
