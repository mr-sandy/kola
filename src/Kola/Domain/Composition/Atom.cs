namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Atom : ParameterisedComponent
    {
        public Atom(string name, IEnumerable<Parameter> parameters = null)
            : base(name, parameters)
        {
        }

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IComponentInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance(
                this.Name,
                this.Parameters.Select(p => p.Build(buildContext)));
        }
    }
}