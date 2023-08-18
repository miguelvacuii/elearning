using elearning.src.CourseAdministration.Course.Application.Query.FindById;
using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment
{
    
    public class EnrollmenrFacade
    {

        private readonly IQueryBus queryBus;

        public EnrollmenrFacade(IQueryBus queryBus)
        {
            this.queryBus = queryBus;
        }

        internal IResponse FindCourseById(string id)
        {
            FindCourseByIdQuery findCourseByIdQuery = new FindCourseByIdQuery(id);
            return queryBus.Ask(findCourseByIdQuery);
        }

        internal IResponse FindStudentById(string id)
        {
            FindUserByIdQuery findUserByIdQuery = new FindUserByIdQuery(id, true);
            return queryBus.Ask(findUserByIdQuery);
        }
    }
}
