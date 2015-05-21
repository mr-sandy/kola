namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetPropertyFixedAmendment : IAmendment
    {
        public SetPropertyFixedAmendment(IEnumerable<int> componentPath, string propertyName, string fixedValue)
        {
            this.ComponentPath = componentPath;
            this.PropertyName = propertyName;
            this.FixedValue = fixedValue;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string PropertyName { get; private set; }

        public string FixedValue { get; private set; }

        public IEnumerable<IEnumerable<int>> SubjectPaths
        {
            get { yield return this.ComponentPath; }
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