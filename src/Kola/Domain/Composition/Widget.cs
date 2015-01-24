namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Extensions;

    public class Widget : ComponentWithProperties
    {
        public Widget(string name, IEnumerable<Area> areas, IEnumerable<Property> properties = null)
            : base(name, properties)
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

        public override T Accept<T, TContext1, TContext2>(IComponentVisitor<T, TContext1, TContext2> visitor, TContext1 context1, TContext2 context2)
        {
            return visitor.Visit(this, context1, context2);
        }

        public override IComponent Clone()
        {
            return new Widget(this.Name, this.Areas.Clone(), this.Properties.Clone());
        }
    }
}