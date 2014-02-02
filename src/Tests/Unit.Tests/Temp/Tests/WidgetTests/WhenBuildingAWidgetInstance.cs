namespace Unit.Tests.Temp.Tests.WidgetTests
{
    using System;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Temp.Domain;
    using Unit.Tests.Temp.Domain.Instances;
    using Unit.Tests.Temp.Domain.Specifications;
    using Unit.Tests.Temp.Domain.Templates;

    public class WhenBuildingAWidgetInstance
    {
        private WidgetInstance instance;

        [SetUp]
        public void EstablishContext()
        {
            var template = new WidgetTemplate(new[] { new Area() });

            var buildContext = MockRepository.GenerateStub<IBuildContext>();
            var widgetSpecification = new WidgetSpecification();

            buildContext.Stub(c => c.WidgetSpecificationLocator).Return(n => widgetSpecification);

            this.instance = (WidgetInstance)template.Build(buildContext);
        }

        [Test]
        public void ShouldHaveAreas()
        {
        }
    }
}