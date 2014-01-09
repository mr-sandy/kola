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
            var specification = this.componentLibrary.Lookup(amendment.ComponentName);
            var component = specification.Create();

            var parent = this.template.FindCollection(amendment.TargetPath.TakeAllButLast());
            var targetIndex = amendment.TargetPath.Last();

            parent.AddComponent(component, targetIndex);
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
    }
}