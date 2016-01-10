namespace Kola.Service.Services.Models
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    public class AmendmentDetails
    {
        public AmendmentDetails(AmendableComponentCollection owner, IAmendment amendment)
        {
            this.Owner = owner;
            this.Amendment = amendment;
        }

        public AmendableComponentCollection Owner { get; }

        public IAmendment Amendment { get; }
    }
}