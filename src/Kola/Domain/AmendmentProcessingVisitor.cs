namespace Kola.Domain
{
    using System.Collections.Generic;

    using Kola.Extensions;
    using Kola.Nancy.Modules;

    public class AmendmentProcessingVisitor : IAmendmentVisitor
    {
        private readonly Template template;
        private readonly IComponentFactory componentFactory;

        public AmendmentProcessingVisitor(Template template, IComponentFactory componentFactory)
        {
            this.template = template;
            this.componentFactory = componentFactory;
        }

        public void Visit(AddComponentAmendment amendment)
        {
            var parent = this.GetComposite(amendment.ComponentPath);

            parent.AddComponent(this.componentFactory.Create(amendment.ComponentType));
        }

        private Composite GetComposite(IEnumerable<int> componentPath)
        {
            var parent = this.template.FindChild(componentPath) as Composite;

            if (parent == null)
            {
                throw new DomainException("Cannot add child: specified component path does not map to composite component");
            }

            return parent;
        }
    }
}