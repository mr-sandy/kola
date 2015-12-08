namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class ClearPropertyAmendment : IAmendment
    {
        public ClearPropertyAmendment(IEnumerable<int> componentPath, string propertyName)
        {
            this.ComponentPath = componentPath;
            this.PropertyName = propertyName;
        }

        public IEnumerable<int> ComponentPath { get; }

        public string PropertyName { get; }

        public IEnumerable<IEnumerable<int>> AffectedPaths
        {
            get { yield return this.ComponentPath; }
        }

        public IEnumerable<int> SubjectPath => this.ComponentPath;

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