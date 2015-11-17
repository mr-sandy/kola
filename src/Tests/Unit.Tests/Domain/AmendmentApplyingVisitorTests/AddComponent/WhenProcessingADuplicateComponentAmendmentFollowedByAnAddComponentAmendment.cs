namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingADuplicateComponentAmendmentFollowedByAnAddComponentAmendment : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.ComponentSpecification.Stub(s => s.Create()).Return(new Atom("new atom"));

            this.Template.Insert(0, new Widget("widget 1", new[] { new Area("area") }));

            var duplicateAmendment = new DuplicateComponentAmendment(new[] { 0 });

            var addComponentAmendment = new AddComponentAmendment(new[] { 1, 0, 0 }, "new atom");

            this.Visitor.Visit(duplicateAmendment);
            this.Visitor.Visit(addComponentAmendment);
        }

        [Test]
        public void TheParentShouldContainTwoComponents()
        {
            this.Template.Components.Should().HaveCount(2);
        }

        [Test]
        public void TheSecondComponentShouldBeAWidget()
        {
            this.Template.Components.Second().Should().BeOfType<Widget>();
        }

        [Test]
        public void TheSecondComponentShouldHaveOneArea()
        {
            var widget = (Widget)this.Template.Components.Second();
            widget.Areas.Should().HaveCount(1);
        }

        [Test]
        public void TheSecondComponentShouldHaveOneChildInItsOnlyArea()
        {
            var widget = (Widget)this.Template.Components.Second();
            var area = widget.Areas.Single();
            area.Components.Should().HaveCount(1);
        }
    }
}