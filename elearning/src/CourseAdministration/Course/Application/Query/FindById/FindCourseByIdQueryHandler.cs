using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseAdministration.Course.Application.Query.FindById
{
    public class FindCourseByIdQueryHandler : IQueryHandler
    {
        private readonly FindCourseByIdUseCase findCourseByIdUseCase;

        public FindCourseByIdQueryHandler(
            FindCourseByIdUseCase findCourseByIdUseCase
        )
        {
            this.findCourseByIdUseCase = findCourseByIdUseCase;
        }

        public IResponse Handle(IQuery query) {
            FindCourseByIdQuery findCourseByIdQuery = query as FindCourseByIdQuery;
            CourseId courseId = new CourseId(findCourseByIdQuery.id);
            return findCourseByIdUseCase.Invoke(courseId);
        }
    }
}
