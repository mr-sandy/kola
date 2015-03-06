namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    public class AmendmentResourceBuilder
    {
        public IEnumerable<AmendmentResource> Build(IEnumerable<IAmendment> amendments, IEnumerable<string> templatePath)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(templatePath);

            return amendments.Select((amendment, index) => amendment.Accept(visitor, index));
        }

        public AmendmentResource Build(IAmendment amendment, IEnumerable<string> templatePath, int index)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(templatePath);

            return amendment.Accept(visitor, index);
        }
    }
}