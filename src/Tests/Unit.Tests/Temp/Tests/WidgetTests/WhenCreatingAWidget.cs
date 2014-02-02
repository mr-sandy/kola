namespace Unit.Tests.Temp.Tests.WidgetTests
{
    using FluentAssertions;

    using NUnit.Framework;

    using Unit.Tests.Temp.Domain.Specifications;
    using Unit.Tests.Temp.Domain.Templates;

    public class WhenCreatingAWidget
    {
        private WidgetTemplate widget;

        [SetUp]
        public void EstablishContext()
        {
            var specification = new WidgetSpecification();

            var placeholder1 = new Placeholder();
            var container = new ContainerTemplate();
            var placeholder2 = new Placeholder();

            specification.Add(placeholder1, new[] { 0 });
            specification.Add(container, new[] { 1 });
            specification.Add(placeholder2, new[] { 1, 0 });

            this.widget = specification.Create();
        }

        [Test]
        public void ShouldHaveTwoAreas()
        {
            this.widget.Areas.Should().HaveCount(2);
        }
    }
}