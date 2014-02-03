namespace Unit.Tests.Temp.Domain.Specifications
{
    using Unit.Tests.Temp.Domain.Templates;

    public class AtomSpecification : IComponentSpecification<AtomTemplate>
    {
        public AtomTemplate Create()
        {
            return new AtomTemplate();
        }
    }
}