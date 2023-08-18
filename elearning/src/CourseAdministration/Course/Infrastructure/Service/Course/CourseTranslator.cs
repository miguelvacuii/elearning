using elearning.src.CourseAdministration.Course.Domain;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Service.Course
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
