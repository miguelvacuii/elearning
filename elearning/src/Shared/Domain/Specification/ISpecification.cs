﻿namespace elearning.src.Shared.Domain.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);

        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> Or(ISpecification<T> other);

        ISpecification<T> Not();
    }
}
