namespace Kola.Domain.Templates.ParameterValues
{
    using System;

    using Kola.Domain.Instances.Building;

    public class FixedParameterValue : IParameterValue
    {
        public FixedParameterValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public string Resolve(IBuildContext buildContext)
        {
            return this.Value;
        }

        public T Accept<T>(IParameterValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}