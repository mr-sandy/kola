namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class Atom : IComponent
    {
        public Atom(string name, IEnumerable<Parameter> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }

        public IEnumerable<Parameter> Parameters { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(BuildContext buildContext)
        {
            return new AtomInstance(
                this.Name,
                this.Parameters.Select(p => p.Build(buildContext)));
        }
    }
}