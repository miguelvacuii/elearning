using System.Collections.Generic;

namespace elearning.src.Shared.Domain.Query.Criteria
{
    public class Criteria
    {
        public List<Criterion> criterion { get; private set; }
        public List<Order> order { get; private set; }
        public Limit limit { get; private set; }
        public Offset offset { get; private set; }

        public Criteria(
            List<Criterion> criterion,
            List<Order> order,
            Limit limit,
            Offset offset
        )
        {
            this.criterion = criterion;
            this.order = order;
            this.limit = limit;
            this.offset = offset;
        }

        public static Criteria Create(
            List<Criterion> criterion,
            List<Order> order,
            Limit limit,
            Offset offset
        ) {
            return new Criteria(criterion, order, limit, offset);
        }
    }
}
