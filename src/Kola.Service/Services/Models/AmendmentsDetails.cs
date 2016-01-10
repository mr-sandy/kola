namespace Kola.Service.Services.Models
{
    using Kola.Domain.Composition;

    public class AmendmentsDetails
    {
        public AmendmentsDetails(AmendableComponentCollection amendableComponentCollection)
        {
            this.Owner = amendableComponentCollection;
        }

        public AmendableComponentCollection Owner { get; }
    }
}