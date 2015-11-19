namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentsDetailsResourceBuilder : IResourceBuilder<AmendmentsDetails>
    {
        public object Build(AmendmentsDetails model)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            return model.Template.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));
        }

        public string Location(AmendmentsDetails widgetSpecification)
        {
            var result = new List<string>();

            result.AddRange(widgetSpecification.Template.Path);
            result.Add("_amendments");

            return result.ToHttpPath();
        }
    }
}