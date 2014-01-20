namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;

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
            return new Parameter(this.Name, this.Type)
                {
                    //Value = new UndefinedParameterValue()
                    Value = new FixedParameterValue(@"##This is the value##\n\nHere is *the stuff*")
                };
        }
    }
}