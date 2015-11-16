namespace Kola.Service.Services.Models
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    public class TemplateAndAmendment
    {
        public TemplateAndAmendment(Template template, IAmendment amendment)
        {
            this.Template = template;
            this.Amendment = amendment;
        }

        public Template Template { get; }

        public IAmendment Amendment { get; }
    }
}