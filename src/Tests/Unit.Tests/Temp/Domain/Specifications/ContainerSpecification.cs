namespace Unit.Tests.Temp.Domain.Specifications
{
    using System.Linq;

    using Unit.Tests.Temp.Domain.Templates;

    public class ContainerSpecification : IComponentSpecification<ContainerTemplate>
    {
        public ContainerTemplate Create()
        {
            return new ContainerTemplate(Enumerable.Empty<IComponentTemplate>());
        }
    }
}