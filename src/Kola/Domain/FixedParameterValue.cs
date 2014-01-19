namespace Kola.Domain
{
    using System.Collections.Generic;

    public class FixedParameterValue : IParameterValue
    {
        public FixedParameterValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public string Resolve(IEnumerable<Context> contexts)
        {
            return this.Value;
        }
    }
}