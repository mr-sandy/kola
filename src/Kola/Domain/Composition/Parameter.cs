namespace Kola.Domain.Composition
{
    using Kola.Domain.Composition.ParameterValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Parameter
    {
        private IParameterValue value;

        public Parameter(string name, string type, IParameterValue value)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }


        public IParameterValue Value
        {
            get
            {
                return this.value;
            }
            
            set
            {
                if (value == null)
                {
                    throw new KolaException("Parameter must have a value");
                }

                this.value = value;
            }
        }

        public ParameterInstance Build(IBuildContext buildContext)
        {
            return new ParameterInstance(this.Name, this.Value.Resolve(buildContext));
        }
    }
}