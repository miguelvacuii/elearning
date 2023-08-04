using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class FindUserByIdQuery : IQuery
    {
        public string id { get; private set; }

        public FindUserByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
