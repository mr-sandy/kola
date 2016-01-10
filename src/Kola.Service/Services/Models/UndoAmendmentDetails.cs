using Kola.Domain.Composition;
using Kola.Domain.Composition.Amendments;

namespace Kola.Service.Services.Models
{
    public class UndoAmendmentDetails
    {
        public UndoAmendmentDetails(AmendableComponentCollection amendableComponentCollection, IAmendment amendment)
        {
            this.Owner = amendableComponentCollection;
            this.Amendment = amendment;
        }

        public AmendableComponentCollection Owner { get; }

        public IAmendment Amendment { get; }
    }
}