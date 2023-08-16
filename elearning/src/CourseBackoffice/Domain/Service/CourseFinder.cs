using elearning.src.CourseBackoffice.Domain.Exception;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Domain.Service
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
