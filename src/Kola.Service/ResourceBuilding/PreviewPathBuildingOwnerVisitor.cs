namespace Kola.Service.ResourceBuilding
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Service.Extensions;

    public class PreviewPathBuildingOwnerVisitor : IAmendableComponentCollectionVisitor<string>
    {
        public string Visit(WidgetSpecification widgetSpecification)
        {
            throw new Exception("Not sure about this");
            //return $"/_kola/widgets/{this.subPath}?name={widgetSpecification.Name}";
        }

        public string Visit(Template template)
        {
            return template.Path.ToHttpPath();
        }
    }
}