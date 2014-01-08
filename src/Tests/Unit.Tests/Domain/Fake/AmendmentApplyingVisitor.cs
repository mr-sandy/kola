namespace Unit.Tests.Domain.Fake
{
    using Unit.Tests.Domain.Fake.Amendments;
    using Unit.Tests.Domain.Fake.Extensions;

    public class AmendmentApplyingVisitor : IAmendmentVisitor
    {
        private readonly Template template;

        private readonly IComponentFactory componentFactory;

        public AmendmentApplyingVisitor(Template template, IComponentFactory componentFactory)
        {
            this.template = template;
            this.componentFactory = componentFactory;
        }

        public void Visit(AddComponentAmendment amendment)
        {
            var parent = this.template.FindComponent(amendment.ParentPath);
            var component = this.componentFactory.Create(amendment.ComponentName);
            parent.AddComponent(component, amendment.Index);
        }
    }
}