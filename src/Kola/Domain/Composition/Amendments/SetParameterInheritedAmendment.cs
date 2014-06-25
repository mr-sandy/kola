namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetParameterInheritedAmendment : IAmendment
    {
        public SetParameterInheritedAmendment(IEnumerable<int> componentPath, string parameterName, string inheritedKey)
        {
            this.ComponentPath = componentPath;
            this.ParameterName = parameterName;
            this.InheritedKey = inheritedKey;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string ParameterName { get; private set; }

        public string InheritedKey { get; private set; }

        public IEnumerable<int> GetRootComponent()
        {
            return this.ComponentPath;
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public T Accept<T>(IAmendmentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}