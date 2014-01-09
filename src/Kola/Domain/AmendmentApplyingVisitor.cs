namespace Kola.Domain
{
    using System;
    using System.Linq;

    using Kola.Domain.Amendments;
    using Kola.Domain.Extensions;
    using Kola.Extensions;

    public class AmendmentApplyingVisitor : IAmendmentVisitor
    {
        private readonly Template template;

        private readonly IComponentLibrary componentLibrary;

        public AmendmentApplyingVisitor(Template template, IComponentLibrary componentLibrary)
        {
            this.template = template;
            this.componentLibrary = componentLibrary;
        }

        public void Visit(AddComponentAmendment amendment)
        {
            var parent = this.template.FindCollection(amendment.ParentPath);
            var specification = this.componentLibrary.Lookup(amendment.ComponentName);
            var component = specification.Create();
            parent.AddComponent(component, amendment.Index);
        }

        public void Visit(MoveComponentAmendment amendment)
        {
            var component = this.template.FindComponent(amendment.ComponentPath);
            var sourceParent = this.template.FindCollection(amendment.ComponentPath.TakeAllButLast());
            var targetParent = this.template.FindCollection(amendment.ParentComponentPath);

            sourceParent.RemoveComponentAt(amendment.ComponentPath.Last());
            targetParent.AddComponent(component, amendment.Index);
        }

        public void Visit(DeleteComponentAmendment amendment)
        {
            var index = amendment.ComponentPath.Last();
            var parent = this.template.FindCollection(amendment.ComponentPath.TakeAllButLast());

            parent.RemoveComponentAt(index);
        }
    }
}