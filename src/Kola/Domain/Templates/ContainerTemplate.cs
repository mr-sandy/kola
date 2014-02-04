namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Instances;

    public class ContainerTemplate : IParameterisedComponent, IComponentCollection
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public ContainerTemplate(string name, IEnumerable<ParameterTemplate> parameters, IEnumerable<IComponentTemplate> components = null)
        {
            this.Name = name;
            this.Parameters = parameters;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterTemplate> Parameters { get; private set; }

        public IEnumerable<IComponentTemplate> Components
        {
            get { return this.components; }
        }

        public void AddComponent(IComponentTemplate component, int index)
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

        public void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            return new ContainerInstance(
                this.Name, 
                this.Parameters.Select(p => p.Build(buildContext)), 
                this.Components.Select(c => c.Build(buildContext)).ToList());
        }
    }
}