namespace Kola.DomainBuilding
{
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    internal class AmendmentDomainBuilder
    {
        public IAmendment Build(AmendmentResource resource)
        {
            var amendmentBuilder = new DomainBuildingAmendmentResourceVisitor();

            return resource.Accept(amendmentBuilder);
        }
    }
}