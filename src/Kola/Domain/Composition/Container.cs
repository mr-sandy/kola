namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Extensions;

    public class Container : ComponentWithgProperties, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public Container(string name, IEnumerable<Property> properties = null, IEnumerable<IComponent> components = null)
            : base(name, properties)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void Insert(int index, IComponent component)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveAt(int index)
        {
            this.components.RemoveAt(index);
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
            var properties = this.Properties.Select(p => p.Build(buildContext)).ToList();

            var newContext = new Context { Items = properties.Select(p => new ContextItem(p.Name, p.Value)) };
            buildContext.PushContext(newContext);
            
            var children = this.Components.Select((c, i) => c.Build(path.Append(i), buildContext)).ToList();

            buildContext.PopContext();

            return new ContainerInstance(path, this.Name, properties, children);
        }
    }
}