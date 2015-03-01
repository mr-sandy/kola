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
            return new RemoveComponentAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment.SubjectPaths, index)
            };
        }

        public AmendmentResource Visit(DuplicateComponentAmendment amendment, int index)
        {
            return new DuplicateComponentAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment.SubjectPaths, index)
            };
        }

        public AmendmentResource Visit(SetPropertyFixedAmendment amendment, int index)
        {
            return new SetPropertyAmendmentResource
                {
                    Id = index,
                    ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                    PropertyName = amendment.PropertyName,
                    Value = amendment.FixedValue,
                    Links = this.BuildLinks(amendment.SubjectPaths, index)
                };
        }

        public AmendmentResource Visit(SetPropertyInheritedAmendment amendment, int index)
        {
            throw new NotImplementedException();
        }

        public AmendmentResource Visit(SetPropertyMultilingualAmendment amendment, int index)
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