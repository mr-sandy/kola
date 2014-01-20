namespace Kola.Domain.Templates
{
    using Kola.Domain.Instances;
    using Kola.Domain.Templates.ParameterValues;

    public class Parameter
    {
        public Parameter(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public IParameterValue Value { get; set; }

        public ParameterInstance Build(BuildContext buildContext)
        {
            return new ParameterInstance(this.Name, this.Value.Resolve(buildContext));
        }
    }
}