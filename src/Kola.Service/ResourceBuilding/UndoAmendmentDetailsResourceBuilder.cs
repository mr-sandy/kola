namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Resources;
    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class UndoAmendmentDetailsResourceBuilder : IResourceBuilder<UndoAmendmentDetails>
    {
        public object Build(UndoAmendmentDetails model)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(model.Owner);

            var amendments = model.Owner.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));

            return new AmendmentsResource
            {
                Amendments = amendments.ToArray(),
                Links = this.GetLinks(model).ToArray()
            };
        }

        private IEnumerable<LinkResource> GetLinks(UndoAmendmentDetails model)
        {
            yield return new LinkResource { Rel = "self", Href = this.Location(model) };

            yield return new LinkResource { Rel = "subject", Href = $"/{string.Join("/", model.Amendment.AffectedPaths.First())}" };

            foreach (var affectedPath in model.Amendment.AffectedPaths)
            {
                yield return new LinkResource { Rel = "affected", Href = $"/{string.Join("/", affectedPath)}" };
            }
        }

        public string Location(UndoAmendmentDetails amendment)
        {
            return amendment.Owner.Accept(new PathBuildingOwnerVisitor("amendments"));
        }
    }
}