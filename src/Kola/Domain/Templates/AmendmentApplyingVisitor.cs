namespace Kola.Domain.Templates
{
    using System;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Templates.Amendments;
    using Kola.Domain.Templates.ParameterValues;
    using Kola.Extensions;

    public class AmendmentApplyingVisitor : IAmendmentVisitor
    {
        private readonly PageTemplate template;

        private readonly IComponentSpecificationLibrary specificationLibrary;

        public AmendmentApplyingVisitor(PageTemplate template, IComponentSpecificationLibrary specificationLibrary)
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

            parent.AddComponent(component, index);
        }

        public void Visit(MoveComponentAmendment amendment)
        {
            var component = this.template.FindComponent(amendment.SourcePath);
            var sourceParent = this.template.FindCollection(amendment.SourcePath.TakeAllButLast());
            var targetParent = this.template.FindCollection(amendment.TargetPath.TakeAllButLast());
            var targetIndex = amendment.TargetPath.Last();

            sourceParent.RemoveComponentAt(amendment.SourcePath.Last());
            targetParent.AddComponent(component, targetIndex);
        }

        public void Visit(RemoveComponentAmendment amendment)
        {
            var index = amendment.ComponentPath.Last();
            var parent = this.template.FindCollection(amendment.ComponentPath.TakeAllButLast());

            parent.RemoveComponentAt(index);
        }

        public void Visit(UpdateParameterAmendment amendment)
        {
            var component = this.template.Find<IParameterisedComponent>(amendment.ComponentPath);

            var parameter = component.Parameters.Where(p => p.Name.Equals(amendment.ParameterName, StringComparison.OrdinalIgnoreCase)).Single();

            parameter.Value = new FixedParameterValue(amendment.UpdatedValue);
        }
    }
}