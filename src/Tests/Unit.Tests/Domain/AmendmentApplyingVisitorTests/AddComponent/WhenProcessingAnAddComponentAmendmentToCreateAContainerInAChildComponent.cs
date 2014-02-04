namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateAContainerInAChildComponent : ContextBase
    {
        private ContainerTemplate container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new ContainerTemplate("existing container", null);
            this.Template.AddComponent(this.container, 0);

            this.ComponentSpecification.Stub(s => s.Create()).Return(new ContainerTemplate("new container", null));

            var amendment = new AddComponentAmendment("new container", new[] { 0, 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheContainerShouldContainOneChild()
        {
            this.container.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAContainer()
        {
            this.container.Components.Single().Should().BeOfType<ContainerTemplate>();
        }
    }
}