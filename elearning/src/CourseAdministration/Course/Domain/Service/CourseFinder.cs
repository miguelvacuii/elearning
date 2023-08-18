using elearning.src.CourseAdministration.Course.Domain.Exception;
using CourseAggregate = elearning.src.CourseAdministration.Course.Domain.Course;

namespace elearning.src.CourseAdministration.Course.Domain.Service
{
    public class CourseFinder
    {
        private readonly ICourseRepository courseRepository;

        public CourseFinder(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseAggregate FindById(CourseId id) {
            CourseAggregate course = courseRepository.Get(id);
            if (course == null)
            {
                throw CourseNotFoundException.FromId(id);
            }
            return course;
        }
    }
}
