namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public class Widget : ComponentWithProperties
    {
        public Widget(string name, IEnumerable<Area> areas, IEnumerable<Property> properties = null, string comment = "")
            : base(name, properties, comment)
        {
            this.Areas = areas;
        }

        public IEnumerable<Area> Areas { get; private set; }

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
            return new Widget(this.Name, this.Areas.Clone(), this.Properties.Clone(), this.Comment);
        }
    }
}