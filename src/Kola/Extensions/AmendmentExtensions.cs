namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Resources;

    internal static class AmendmentExtensions
    {
        public static IEnumerable<AmendmentResource> ToResource(this IEnumerable<Amendment> amendments, IEnumerable<string> templatePath)
        {
            var visitor = new AmendmentResourceBuildingVisitor(templatePath, amendments.Count());

            foreach (var amendment in amendments)
            {
                amendment.Accept(visitor);
            }

            return visitor.AmendmentResources;
        }

        public static AddComponentAmendmentResource ToResource(this AddComponentAmendment amendment, IEnumerable<string> templatePath, int index, bool isLast)
        {
            return new AddComponentAmendmentResource
            {
                Type = "Add Component",
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                ComponentType = amendment.ComponentType,
                Index = amendment.Index,
                Links = BuildLinks(templatePath, amendment.GetRootComponent(), index, isLast)
            };
        }

        public static MoveComponentAmendmentResource ToResource(this MoveComponentAmendment amendment, IEnumerable<string> templatePath, int index, bool isLast)
        {
            return new MoveComponentAmendmentResource
            {
                Type = "Move Component",
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Index = amendment.Index,
                Links = BuildLinks(templatePath, amendment.GetRootComponent(), index, isLast)
            };
        }

        public static DeleteComponentAmendmentResource ToResource(this DeleteComponentAmendment amendment, IEnumerable<string> templatePath, int index, bool isLast)
        {
            return new DeleteComponentAmendmentResource
            {
                Type = "Delete Component",
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = BuildLinks(templatePath, amendment.GetRootComponent(), index, isLast)
            };
        }

        private static IEnumerable<LinkResource> BuildLinks(IEnumerable<string> templatePath, IEnumerable<int> rootComponent, int index, bool isLast)
        {
            var path = templatePath.Concat(new[] { "_amendments", index.ToString() }).ToHttpPath();

            yield return new LinkResource
                {
                    Rel = "self",
                    Href = path
                };

            yield return new LinkResource
            {
                Rel = "subject",
                Href = templatePath.Append("_components").Concat(rootComponent.Select(i => i.ToString())).ToHttpPath()
            };

            if (isLast)
            {
                yield return new LinkResource
                {
                    Rel = "undo",
                    Href = path
                };
            }
        }
    }
}