namespace elearning.src.Shared.Domain.Query.Criteria
{
    public class Criterion
    {
        public CriterionField field { get; private set; }
        public CriterionValue value { get; private set; }
        public CriterionOperator crOperator { get; private set; }

        public Criterion(
            CriterionField field,
            CriterionValue value,
            CriterionOperator crOperator
        ) {
            this.field = field;
            this.value = value;
            this.crOperator = crOperator;
        }

        public static Criterion Create(string field, string value) {

            return new Criterion(
                new CriterionField(field),
                new CriterionValue(value),
                new CriterionOperator("=")
            );
        }
    }
}
