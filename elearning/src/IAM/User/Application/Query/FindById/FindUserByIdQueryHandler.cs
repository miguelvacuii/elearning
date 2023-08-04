using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class FindUserByIdQueryHandler : IQueryHandler
    {
        private readonly FindUserByIdUseCase findUserByIdUseCase;

        public FindUserByIdQueryHandler(
            FindUserByIdUseCase findUserByIdUseCase
        )
        {
            this.findUserByIdUseCase = findUserByIdUseCase;
        }

        public IResponse Handle(IQuery query) {
            FindUserByIdQuery findUserByIdQuery = query as FindUserByIdQuery;
            UserId userId = new UserId(findUserByIdQuery.id);
            return findUserByIdUseCase.Invoke(userId);
        }
    }
}
