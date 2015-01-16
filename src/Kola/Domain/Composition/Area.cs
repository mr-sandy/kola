namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Extensions;

    public class Area : IComponentCollection, IComponent
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public Area(string name, IEnumerable<IComponent> components = null)
        {
            this.Name = name;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

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

        public T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public ComponentInstance Build(IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AreaInstance(path, this.Components.Select((c, i) => c.Build(path.Append(i), buildContext)).ToList());
        }
    }
}