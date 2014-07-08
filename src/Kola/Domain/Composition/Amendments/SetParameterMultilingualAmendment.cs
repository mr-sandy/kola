namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetParameterMultilingualAmendment : IAmendment
    {
        public SetParameterMultilingualAmendment(IEnumerable<int> componentPath, string parameterName, string languageCode, string value)
        {
            this.ComponentPath = componentPath;
            this.ParameterName = parameterName;
            this.LanguageCode = languageCode;
            this.Value = value;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string ParameterName { get; private set; }

        public string LanguageCode { get; private set; }

        public string Value { get; private set; }

        public IEnumerable<IEnumerable<int>> SubjectPaths
        {
            get
            {
                yield return this.ComponentPath;
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