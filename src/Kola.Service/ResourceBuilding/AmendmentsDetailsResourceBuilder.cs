namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Resources;
    using Kola.Service.Services.Models;

    public class AmendmentsDetailsResourceBuilder : IResourceBuilder<AmendmentsDetails>
    {
        public object Build(AmendmentsDetails model)
        {       
            var visitor = new ResourceBuildingAmendmentVisitor(model.Owner);

            var amendments = model.Owner.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));

            return new AmendmentsResource
            {
                Amendments = amendments.ToArray(),
                Links = this.GetLinks(model).ToArray()
            };
        }

        public string Location(AmendmentsDetails amendment)
        {
            return amendment.Owner.Accept(new PathBuildingOwnerVisitor("amendments"));
        }

        private IEnumerable<LinkResource> GetLinks(AmendmentsDetails model)
        {
            yield return new LinkResource { Rel = "self", Href = this.Location(model) };
        }
    }
}