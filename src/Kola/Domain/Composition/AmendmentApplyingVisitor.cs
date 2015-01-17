namespace Kola.Domain.Composition
{
    using System;
    using System.Linq;

    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Extensions;
    using Kola.Extensions;

    public class AmendmentApplyingVisitor : IAmendmentVisitor
    {
        private readonly Template template;

        private readonly IComponentSpecificationLibrary specificationLibrary;

        public AmendmentApplyingVisitor(Template template, IComponentSpecificationLibrary specificationLibrary)
        {
            this.template = template;
            this.specificationLibrary = specificationLibrary;
        }

        public void Visit(AddComponentAmendment amendment)
        {
            var specification = this.specificationLibrary.Lookup(amendment.ComponentName);
            var component = specification.Create();

            var parent = this.template.FindCollection(amendment.TargetPath.TakeAllButLast());
            var index = amendment.TargetPath.Last();

            parent.Insert(index, component);
        }

        public void Visit(MoveComponentAmendment amendment)
        {
            var component = this.template.FindComponent(amendment.SourcePath);
            var sourceParent = this.template.FindCollection(amendment.SourcePath.TakeAllButLast());
            var targetParent = this.template.FindCollection(amendment.TargetPath.TakeAllButLast());
            var targetIndex = amendment.TargetPath.Last();

            sourceParent.RemoveAt(amendment.SourcePath.Last());
            targetParent.Insert(targetIndex, component);
        }

        public void Visit(RemoveComponentAmendment amendment)
        {
            var index = amendment.ComponentPath.Last();
            var parent = this.template.FindCollection(amendment.ComponentPath.TakeAllButLast());

            parent.RemoveAt(index);
        }

        public void Visit(SetPropertyFixedAmendment amendment)
        {
            var component = this.template.FindComponentWithProperties(amendment.ComponentPath);
            var specification = this.specificationLibrary.Lookup(component.Name);

            var property = component.FindOrCreateProperty(specification.Properties.Find(amendment.PropertyName));

            property.Value = new FixedPropertyValue(amendment.FixedValue);
        }

        public void Visit(SetPropertyInheritedAmendment amendment)
        {
            throw new NotImplementedException();
        }

        public void Visit(SetPropertyMultilingualAmendment amendment)
        {
            var component = this.template.FindComponentWithProperties(amendment.ComponentPath);
            var specification = this.specificationLibrary.Lookup(component.Name);
        }
    }
}