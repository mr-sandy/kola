namespace Kola.Domain
{
    using System.Collections.Generic;

    public class Parameter
    {
        public Parameter(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public IParameterValue Value { get; set; }

        public ParameterInstance CreateInstance(IEnumerable<Context> contexts)
        {
            return new ParameterInstance(this.Name, this.Value.Resolve(contexts));
        }
    }
}