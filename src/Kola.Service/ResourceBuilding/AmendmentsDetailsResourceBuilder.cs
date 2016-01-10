namespace Kola.Service.ResourceBuilding
{
    using System;
    using System.Linq;

    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentsDetailsResourceBuilder : IResourceBuilder<AmendmentsDetails>
    {
        public object Build(AmendmentsDetails model)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(model.Owner);

            return model.Owner.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));
        }

        public string Location(AmendmentsDetails amendment)
        {
            return amendment.Owner.Accept(new PathBuildingOwnerVisitor("amendments"));
        }
    }
}