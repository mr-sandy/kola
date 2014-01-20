namespace Kola.Domain.Templates.Amendments
{
    using System.Collections.Generic;

    public class UpdateParameterAmendment : IAmendment
    {
        public UpdateParameterAmendment(string parameterName, string updatedValue, IEnumerable<int> componentPath)
        {
            this.ParameterName = parameterName;
            this.UpdatedValue = updatedValue;
            this.ComponentPath = componentPath;
        }

        public string ParameterName { get; private set; }

        public string UpdatedValue { get; private set; }

        public IEnumerable<int> ComponentPath { get; private set; }

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