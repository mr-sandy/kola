namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public interface IAmendment
    {
        IEnumerable<int> GetRootComponent();

        void Accept(IAmendmentVisitor visitor);

        T Accept<T>(IAmendmentVisitor<T> visitor);
    }
}