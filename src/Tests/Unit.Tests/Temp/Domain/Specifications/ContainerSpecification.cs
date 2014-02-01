namespace Unit.Tests.Temp.Domain.Specifications
{
    using Unit.Tests.Temp.Domain.Templates;

    public class ContainerSpecification : ISpecification<ContainerTemplate>
    {
        public ContainerTemplate Create()
        {
            return new ContainerTemplate();
        }
    }
}