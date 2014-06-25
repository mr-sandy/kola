namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    using Kola.Extensions;

    public class RemoveComponentAmendment : IAmendment
    {
        public RemoveComponentAmendment(IEnumerable<int> componentPath)
        {
            this.ComponentPath = componentPath;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerable<int> GetRootComponent()
        {
            return this.ComponentPath.TakeAllButLast();
        }

        public T Accept<T>(IAmendmentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public T Accept<T, TContext>(IAmendmentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }
    }
}