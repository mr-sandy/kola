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
            var index = this.GetAmendmentIndex(model.Template, model.Amendment);

            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            return model.Amendment.Accept(visitor, index);

        }

        public string Location(AmendmentDetails amendment)
        {
            return $"/_kola/template/amendments?templatePath={amendment.Template.Path.ToHttpPath()}&amendmentIndex={this.GetAmendmentIndex(amendment.Template, amendment.Amendment)}";
        }

        private int GetAmendmentIndex(Template template, IAmendment amendment)
        {
            return template.Amendments.Select((a, i) => new { Amendment = a, Index = i }).First(a => a.Amendment == amendment).Index;
        }
    }
}