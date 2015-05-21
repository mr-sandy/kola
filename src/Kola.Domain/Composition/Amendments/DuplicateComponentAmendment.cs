namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;

    public class DuplicateComponentAmendment : IAmendment
    {
        public DuplicateComponentAmendment(IEnumerable<int> componentPath)
        {
            this.ComponentPath = componentPath;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public IEnumerable<IEnumerable<int>> AffectedPaths
        {
            get { yield return this.ComponentPath.TakeAllButLast(); }
        }

        public IEnumerable<int> SubjectPath
        {
            get { return this.ComponentPath.IncrementLast(); }
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
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