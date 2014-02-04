namespace Kola.Domain.Templates
{
    using Kola.Domain.Instances;
    using Kola.Domain.Templates.ParameterValues;

    public class ParameterTemplate
    {
        public ParameterTemplate(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public IParameterValue Value { get; set; }

        public ParameterInstance Build(IBuildContext buildContext)
        {
            return new ParameterInstance(this.Name, this.Value.Resolve(buildContext));
        }
    }
}