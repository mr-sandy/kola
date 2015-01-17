namespace Kola.Domain.Composition
{
    internal class ComponentRefreshingVisitor : IComponentVisitor
    {
        private readonly IComponentSpecificationLibrary componentLibrary;

        public ComponentRefreshingVisitor(IComponentSpecificationLibrary componentLibrary)
        {
            this.componentLibrary = componentLibrary;
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
        }

        public void Visit(Widget widget)
        {
            var specification = this.componentLibrary.Lookup(widget.Name);
            foreach (var propertySpecification in specification.Properties)
            {
                widget.FindOrCreateProperty(propertySpecification);
            }

            // TODO 2015 - SYnc widget areas here 
        }

        public void Visit(Placeholder placeholder)
        {
        }

        public void Visit(Area area)
        {
        }
    }
}