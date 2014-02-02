namespace Unit.Tests.Temp.Tests.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Unit.Tests.Temp.Domain.Specifications;
    using Unit.Tests.Temp.Domain.Templates;

    public class WhenComposingAWidgetSpecification
    {
        private WidgetSpecification specification;

        [SetUp]
        public void EstablishContext()
        {
            this.specification = new WidgetSpecification();

            this.specification.Add(new AtomTemplate(), new[] { 0 });
            this.specification.Add(new ContainerTemplate(), new[] { 1 });
            this.specification.Add(new WidgetTemplate(Enumerable.Empty<Area>()), new[] { 2 });
            this.specification.Add(new Placeholder(), new[] { 3 });
        }

        [Test]
        public void ShouldHaveFourComponents()
        {
            this.specification.Components.Should().HaveCount(4);
        }
    }
}