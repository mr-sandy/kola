namespace Kola.Domain.Templates
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public class Atom : IComponent
    {
        public Atom(string name, IEnumerable<Parameter> parameters = null)
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
            return new AtomInstance(this.Name);
        }
    }
}