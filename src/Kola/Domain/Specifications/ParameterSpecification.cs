namespace Kola.Domain.Specifications
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;

    public class ParameterSpecification
    {
        public ParameterSpecification(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public Parameter Create()
        {
            var value = new FixedParameterValue(string.Empty);

            return new Parameter(this.Name, this.Type, value);
        }
    }
}