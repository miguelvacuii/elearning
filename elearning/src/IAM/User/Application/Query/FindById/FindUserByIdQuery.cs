using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class FindUserByIdQuery : IQuery
    {
        public string id { get; private set; }
        public bool isInternalQuery { get; private set; }

        public FindUserByIdQuery(string id, bool isInternalQuery = false)
        {
            this.id = id;
            this.isInternalQuery = isInternalQuery;
        }
    }
}
