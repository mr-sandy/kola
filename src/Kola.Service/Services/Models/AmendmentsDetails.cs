namespace Kola.Service.Services.Models
{
    using Kola.Domain.Composition;

    public class AmendmentsDetails
    {
        public AmendmentsDetails(Template template)
        {
            this.Template = template;
        }

        public Template Template { get; }
    }
}