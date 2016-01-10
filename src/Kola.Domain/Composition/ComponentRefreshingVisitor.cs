namespace Kola.Domain.Composition
{
    public class ComponentRefreshingVisitor : IComponentVisitor
    {
        private readonly IComponentSpecificationLibrary componentLibrary;

        public ComponentRefreshingVisitor(IComponentSpecificationLibrary componentLibrary)
        {
            this.componentLibrary = componentLibrary;
        }

        public void Refresh(IComponentCollection componentCollection)
        {
            foreach (var component in componentCollection.Components)
            {
                component.Accept(this);
            }
        }

        public void Visit(Atom atom)
        {
            var specification = this.componentLibrary.Lookup(atom.Name);
            foreach (var propertySpecification in specification.Properties)
            {
                atom.FindOrCreateProperty(propertySpecification);
            }
        }

        public void Visit(Container container)
        {
            var specification = this.componentLibrary.Lookup(container.Name);
            foreach (var propertySpecification in specification.Properties)
            {
                container.FindOrCreateProperty(propertySpecification);
            }

            foreach (var component in container.Components)
            {
                component.Accept(this);
            }
        }

        public void Visit(Widget widget)
        {
            var specification = this.componentLibrary.Lookup(widget.Name);
            foreach (var propertySpecification in specification.Properties)
            {
                widget.FindOrCreateProperty(propertySpecification);
            }

            foreach (var area in widget.Areas)
            {
                area.Accept(this);
            }
        }

        public void Visit(Placeholder placeholder)
        {
        }

        public void Visit(Area area)
        {
            foreach (var component in area.Components)
            {
                component.Accept(this);
            }
        }
    }
}