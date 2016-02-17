namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public class Atom : ComponentWithProperties
    {
        public Atom(string name, IEnumerable<Property> properties = null, string comment = "")
            : base(name, properties, comment)
        {
        }

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override ComponentInstance Build(IBuilder builder, IEnumerable<int> path, IBuildData buildData)
        {
            return builder.Build(this, path, buildData);
        }

        public override IComponent Clone()
        {
            return new Atom(this.Name, this.Properties.Clone(), this.Comment);
        }
    }
}