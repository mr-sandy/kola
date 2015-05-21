namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetPropertyInheritedAmendment : IAmendment
    {
        public SetPropertyInheritedAmendment(IEnumerable<int> componentPath, string propertyName, string inheritedKey)
        {
            this.ComponentPath = componentPath;
            this.PropertyName = propertyName;
            this.InheritedKey = inheritedKey;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string PropertyName { get; private set; }

        public string InheritedKey { get; private set; }

        public IEnumerable<IEnumerable<int>> AffectedPaths
        {
            get { yield return this.ComponentPath; }
        }

        public IEnumerable<int> SubjectPath
        {
            get { return this.ComponentPath; }
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