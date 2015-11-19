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
            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            var amendments = model.Template.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));

            return new UndoAmendmentResource
            {
                Amendments = amendments.ToArray(),
                Links = this.GetLinks(model)
            };
        }

        private IEnumerable<LinkResource> GetLinks(UndoAmendmentDetails model)
        {
            yield return new LinkResource { Rel = "self", Href = this.Location(model) };

            yield return new LinkResource { Rel = "subject", Href = string.Join("/", model.Amendment.AffectedPaths.First()) };

            foreach (var affectedPath in model.Amendment.AffectedPaths)
            {
                yield return new LinkResource { Rel = "affected", Href = string.Join("/", affectedPath) };
            }
        }

        public string Location(UndoAmendmentDetails widgetSpecification)
        {
            var result = new List<string>();

            result.AddRange(new[] { "_kola", "templates" });
            result.AddRange(widgetSpecification.Template.Path);
            result.Add("_amendments");

            return result.ToHttpPath();
        }
    }
}