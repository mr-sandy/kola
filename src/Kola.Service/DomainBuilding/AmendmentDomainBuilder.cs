namespace Kola.Service.DomainBuilding
{
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    public class AmendmentDomainBuilder
    {
        public IAmendment Build(AmendmentResource resource)
        {
            var amendmentBuilder = new DomainBuildingAmendmentResourceVisitor();

            return resource.Accept(amendmentBuilder);
        }
    }
}