namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;

    public class ParameterSpecification
    {
        public ParameterSpecification(string name, string type, string defaultValue = "")
        {
            this.Name = name;
            this.Type = type;
            this.DefaultValue = defaultValue;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public string DefaultValue { get; private set; }

        public ParameterTemplate Create()
        {
            return new ParameterTemplate(this.Name, this.Type)
                {
                    Value = string.IsNullOrEmpty(this.DefaultValue)
                            ? (IParameterValue)new UndefinedParameterValue()
                            : new FixedParameterValue(this.DefaultValue)
                };
        }
    }
}