namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetParameterFixedAmendment : IAmendment
    {
        public SetParameterFixedAmendment(IEnumerable<int> componentPath, string parameterName, string fixedValue)
        {
            this.ComponentPath = componentPath;
            this.ParameterName = parameterName;
            this.FixedValue = fixedValue;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string ParameterName { get; private set; }

        public string FixedValue { get; private set; }

        public IEnumerable<int> SubjectPath
        {
            get
            {
                return this.ComponentPath;
            }
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