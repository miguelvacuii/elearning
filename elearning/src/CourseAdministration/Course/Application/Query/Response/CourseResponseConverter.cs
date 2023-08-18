using CourseAggregate = elearning.src.CourseAdministration.Course.Domain.Course;

namespace elearning.src.CourseAdministration.Course.Application.Query.Response
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
