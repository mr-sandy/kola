namespace Unit.Tests.Domain.Fake
{
    using Unit.Tests.Domain.Fake.Amendments;
    using Unit.Tests.Domain.Fake.Extensions;

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
            var parent = this.template.FindComponent(amendment.ParentPath);
            var specification = this.componentLibrary.Lookup(amendment.ComponentName);
            var component = specification.Create();
            parent.AddComponent(component, amendment.Index);
        }
    }
}