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

        public IEnumerable<int> GetRootComponent()
        {
            return this.ComponentPath;
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}