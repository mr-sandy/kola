namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

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

        public T Accept<T, TContext1, TContext2>(IComponentVisitor<T, TContext1, TContext2> visitor, TContext1 context1, TContext2 context2)
        {
            return visitor.Visit(this, context1, context2);
        }

        public IComponent Clone()
        {
            return new Placeholder(this.Name);
        }
    }
}