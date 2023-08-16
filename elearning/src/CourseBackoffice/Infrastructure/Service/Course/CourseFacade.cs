using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseBackoffice.Infrastructure.Service.Course
{
    public class CourseFacade
    {
        private readonly IQueryBus queryBus;

        public CourseFacade(IQueryBus queryBus)
        {
            this.queryBus = queryBus;
        }

        public virtual IResponse FindTeacherById(string id)
        {
            FindUserByIdQuery findUserById = new FindUserByIdQuery(id, true);
            return queryBus.Ask(findUserById);
        }
    }
}
