namespace Kola.ResourceBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition.Amendments;
    using Kola.Extensions;
    using Kola.Resources;

    internal class ResourceBuildingAmendmentVisitor : IAmendmentVisitor<AmendmentResource, int>
    {
        private readonly IEnumerable<string> templatePath;

        public ResourceBuildingAmendmentVisitor(IEnumerable<string> templatePath)
        {
            this.templatePath = templatePath;
        }

        public AmendmentResource Visit(AddComponentAmendment amendment, int index)
        {
            return new AddComponentAmendmentResource
            {
                Id = index,
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                ComponentType = amendment.ComponentName,
                Links = this.BuildLinks(amendment.SubjectPaths, index)
            };
        }

        public AmendmentResource Visit(MoveComponentAmendment amendment, int index)
        {
            return new MoveComponentAmendmentResource
            {
                Id = index,
                SourcePath = amendment.SourcePath.ToComponentPathString(),
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment.SubjectPaths, index)
            };
        }

        public AmendmentResource Visit(RemoveComponentAmendment amendment, int index)
        {
            return new DeleteComponentAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment.SubjectPaths, index)
            };
        }

        public AmendmentResource Visit(SetParameterFixedAmendment amendment, int index)
        {
            throw new NotImplementedException();
        }

        public AmendmentResource Visit(SetParameterInheritedAmendment amendment, int index)
        {
            throw new NotImplementedException();
        }

        public AmendmentResource Visit(SetParameterMultilingualAmendment amendment, int index)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<LinkResource> BuildLinks(IEnumerable<IEnumerable<int>> subjectPaths, int index)
        {
            var path = this.templatePath.Concat(new[] { "_amendments", index.ToString() }).ToHttpPath();

            yield return new LinkResource
            {
                Rel = "self",
                Href = path
            };

            foreach (var subjectPath in subjectPaths)
            {
                yield return new LinkResource { Rel = "subject", Href = subjectPath.ToComponentPathString() };
            }

            //if (isLast)
            //{
            //    yield return new LinkResource
            //    {
            //        Rel = "undo",
            //        Href = path
            //    };
            //}
        }
    }
}