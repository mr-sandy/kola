namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Container : ParameterisedComponent, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public Container(string name, IEnumerable<Parameter> parameters = null, IEnumerable<IComponent> components = null)
            : base(name, parameters)
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

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override IComponentInstance Build(IBuildContext buildContext)
        {
            return new ContainerInstance(
                this.Name, 
                this.Parameters.Select(p => p.Build(buildContext)), 
                this.Components.Select(c => c.Build(buildContext)).ToList());
        }
    }
}