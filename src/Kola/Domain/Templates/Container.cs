namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Instances;

    public class Container : IParameterisedComponent, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public Container(string name, IEnumerable<Parameter> parameters, IEnumerable<IComponent> components = null)
        {
            this.Name = name;
            this.Parameters = parameters;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<Parameter> Parameters { get; private set; }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void AddComponent(IComponent component, int index)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveComponentAt(int index)
        {
            this.components.RemoveAt(index);
        }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(BuildContext buildContext)
        {
            return new ContainerInstance(
                this.Name, 
                this.Parameters.Select(p => p.Build(buildContext)), 
                this.Components.Select(c => c.Build(buildContext)));
        }
    }
}