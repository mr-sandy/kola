namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentDetailsResourceBuilder : IResourceBuilder<AmendmentDetails>
    {
        public object Build(AmendmentDetails model)
        {
            var index = this.GetAmendmentIndex(model.Owner, model.Amendment);

            var visitor = new ResourceBuildingAmendmentVisitor(model.Owner);

            return model.Amendment.Accept(visitor, index);

        }

        public string Location(AmendmentDetails amendment)
        {
            var ownerPath = amendment.Owner.Accept(new PathBuildingOwnerVisitor("amendments"));

            return $"{ownerPath}&amendmentIndex={this.GetAmendmentIndex(amendment.Owner, amendment.Amendment)}";
        }

        private int GetAmendmentIndex(AmendableComponentCollection owner, IAmendment amendment)
        {
            return owner.Amendments.Select((a, i) => new { Amendment = a, Index = i }).First(a => a.Amendment == amendment).Index;
        }
    }
}