namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public class Placeholder : IComponent
    {
        public Placeholder(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public ComponentInstance Build(IBuilder builder, IEnumerable<int> path, IBuildData buildData)
        {
            return builder.Build(this, path, buildData);
        }

        public IComponent Clone()
        {
            return new Placeholder(this.Name);
        }
    }
}