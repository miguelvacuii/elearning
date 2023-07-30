using System;
using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Domain.Query.Criteria;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace elearning.src.Shared.Infrastructure.Bus.Query.Criteria
{
    public class CriteriaQueryBase : IQuery
    {
        private readonly IQueryCollection query;
        public int limit { get; private set; }
        public int offset { get; private set; }

        public CriteriaQueryBase(IQueryCollection query)
        {
            this.query = query;
            this.limit = query.ContainsKey("page[Size]") ? Int16.Parse(query["page[Size]"]) : 10;
            this.offset = query.ContainsKey("page[Number]") ? Int16.Parse(query["page[Number]"]) : 1;
        }

        public List<Criterion> ToCriterion() {

            List<Criterion> listCriterion = new List<Criterion>();

            foreach (string key in query.Keys) {

                if (key.Contains("filter")) {

                    StringValues @value = new StringValues();
                    query.TryGetValue(key, out value);

                    string field = key;
                    field = field.Replace("filter", "");
                    field = field.Replace("[", "");
                    field = field.Replace("]", "");

                    Criterion criterion = Criterion.Create(field, value.ToString());
                    listCriterion.Add(criterion);                  
                }
            }

            return listCriterion;
        }

        public List<Order> ToOrder()
        {
            List<Order> listOrder = new List<Order>();

            if (query.TryGetValue("sort", out var sortValues)) {
                string[] sortFields = sortValues.ToString().Split(',');

                foreach (string field in sortFields) {
                    string orderBy = field;
                    string orderType = OrderTypeEnum.ASC.ToString();

                    if (field[0] == '-') {
                        orderType = OrderTypeEnum.DESC.ToString();
                        orderBy = field.Remove(0, 1);
                    }

                    Order order = Order.Create(orderBy, orderType);

                    listOrder.Add(order);
                }
            }

            return listOrder;
        }


    }
}
