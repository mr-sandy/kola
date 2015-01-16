namespace Unit.Tests.Domain.ComponentSpecifications
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAWidgetFromItsSpecification
    {
        private Widget widget;

        [SetUp]
        public void SetUp()
        {
            var widgetSpecification = new WidgetSpecification("widget");
            widgetSpecification.Insert(0, new Placeholder("area 1"));
            widgetSpecification.Insert(1, new Placeholder("area 2"));

            this.widget = widgetSpecification.Create();
        }

        [Test]
        public void TheWidgetShouldHaveTheCorrectName()
        {
            this.widget.Name.Should().Be("widget");
        }

        [Test]
        public void TheWidgetShouldHaveTheTwoAreas()
        {
            this.widget.Areas.Should().HaveCount(2);
        }

        [Test]
        public void TheFirstAreaShouldBeNamedCorrectly()
        {
            this.widget.Areas.First().Name.Should().Be("area 1");
        }

        [Test]
        public void TheSecondAreaShouldBeNamedCorrectly()
        {
            this.widget.Areas.Second().Name.Should().Be("area 2");
        }
    }
}