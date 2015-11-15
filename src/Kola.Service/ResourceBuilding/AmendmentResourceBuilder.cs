namespace Kola.Service.ResourceBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    public class AmendmentResourceBuilder : IResourceBuilder<Tuple<Template, IAmendment>>
    {
        public object Build(Tuple<Template, IAmendment> model)
        {
            return this.Build(model.Item2, model.Item1.Path, model.Item1.Amendments.Count() - 1);
        }

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