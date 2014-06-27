namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public interface IAmendment
    {
        IEnumerable<int> SubjectPath { get; }

        void Accept(IAmendmentVisitor visitor);

        T Accept<T>(IAmendmentVisitor<T> visitor);

        T Accept<T, TContext>(IAmendmentVisitor<T, TContext> visitor, TContext context);
    }
}