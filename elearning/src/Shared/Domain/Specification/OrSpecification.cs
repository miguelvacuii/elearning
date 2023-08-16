namespace elearning.src.Shared.Domain.Specification
{
    public class NotSpecification<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> other;

        public NotSpecification(ISpecification<T> other)
        {
            this.other = other;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !other.IsSatisfiedBy(candidate);
        }
    }
}
