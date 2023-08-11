using elearning.src.CourseBackoffice.Domain;

namespace elearning.src.CourseBackoffice.Infrastructure.Service.Course
{
    public class CourseTranslator
    {
        public virtual Teacher FromRepresentationToTeacher(dynamic userResponse)
        {
            return new Teacher(
                userResponse.id,
                userResponse.email,
                userResponse.firstName,
                userResponse.lastName,
                userResponse.role
            );
        }
    }
}
