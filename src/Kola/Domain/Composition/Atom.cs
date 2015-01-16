namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Atom : ComponentWithProperties
    {
        public Atom(string name, IEnumerable<Property> properties = null)
            : base(name, properties)
        {
        }

        public override T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override ComponentInstance Build(IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AtomInstance(
                path,
                this.Name,
                this.Properties.Select(p => p.Build(buildContext)).ToList());
        }
    }
}