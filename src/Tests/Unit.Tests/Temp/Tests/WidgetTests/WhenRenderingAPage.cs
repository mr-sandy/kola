namespace Unit.Tests.Temp.Tests.WidgetTests
{
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

            this.widget = specification.Create();
        }

        [Test]
        public void ShouldHaveAreas()
        {
        }
    }
}