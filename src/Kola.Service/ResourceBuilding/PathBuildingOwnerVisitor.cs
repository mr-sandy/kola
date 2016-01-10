namespace Kola.Service.ResourceBuilding
{
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Service.Extensions;

    public class PathBuildingOwnerVisitor : IAmendableComponentCollectionVisitor<string>
    {
        private readonly string subPath;

        public PathBuildingOwnerVisitor(string subPath)
        {
            this.subPath = subPath;
        }

        public string Visit(WidgetSpecification widgetSpecification)
        {
            return $"/_kola/widgets/{this.subPath}?widgetName={widgetSpecification.Name}";
        }

        public string Visit(Template template)
        {
            return $"/_kola/templates/{this.subPath}?templatePath={template.Path.ToHttpPath()}";
        }
    }
}