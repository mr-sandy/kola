namespace Unit.Tests.Temp.Domain.Specifications
{
    using System.Linq;

    using Unit.Tests.Temp.Domain.Homeless;
    using Unit.Tests.Temp.Domain.Templates;

    public class WidgetSpecification : ISpecification<WidgetTemplate>
    {
        public WidgetTemplate Create()
        {
            return new WidgetTemplate(Enumerable.Empty<Area>());
        }
    }
}