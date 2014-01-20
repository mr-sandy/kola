namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    public class AtomInstance : IComponentInstance
    {
        public AtomInstance(string name, IEnumerable<ParameterInstance> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterInstance> Parameters { get; private set; }

        public T Accept<T>(IComponentInstanceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}