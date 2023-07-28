namespace elearning.src.Shared.Domain.Query.Criteria
{
    public class Order 
    {
        public OrderBy orderBy { get; private set;  }
        public OrderType orderType { get; private set; }

        private Order(OrderBy orderBy, OrderType orderType) {
            this.orderBy = orderBy;
            this.orderType = orderType;
        }

        public static Order Create(string orderBy, string orderType) {
            return new Order(
                new OrderBy(orderBy),
                new OrderType(orderType)
            );
        }
    }
}
