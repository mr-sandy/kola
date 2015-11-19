using Kola.Domain.Composition;
using Kola.Domain.Composition.Amendments;

namespace Kola.Service.Services.Models
{
    public class UndoAmendmentDetails
    {
        public UndoAmendmentDetails(Template template, IAmendment amendment)
        {
            this.Template = template;
            this.Amendment = amendment;
        }

        public Template Template { get; }

        public IAmendment Amendment { get; }
    }
}