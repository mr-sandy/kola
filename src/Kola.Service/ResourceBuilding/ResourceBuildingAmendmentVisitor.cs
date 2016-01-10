namespace Kola.Service.ResourceBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;
    using Kola.Service.Extensions;

    internal class ResourceBuildingAmendmentVisitor : IAmendmentVisitor<AmendmentResource, int>
    {
        private readonly AmendableComponentCollection owner;

        public ResourceBuildingAmendmentVisitor(AmendableComponentCollection owner)
        {
            this.owner = owner;
        }

        public AmendmentResource Visit(AddComponentAmendment amendment, int index)
        {
            return new AddComponentAmendmentResource
            {
                Id = index,
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                ComponentType = amendment.ComponentName,
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(MoveComponentAmendment amendment, int index)
        {
            return new MoveComponentAmendmentResource
            {
                Id = index,
                SourcePath = amendment.SourcePath.ToComponentPathString(),
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(RemoveComponentAmendment amendment, int index)
        {
            return new RemoveComponentAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(DuplicateComponentAmendment amendment, int index)
        {
            return new DuplicateComponentAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(SetPropertyFixedAmendment amendment, int index)
        {
            return new SetPropertyFixedAmendmentResource
                {
                    Id = index,
                    ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                    PropertyName = amendment.PropertyName,
                    Value = amendment.FixedValue,
                    Links = this.BuildLinks(amendment, index)
                };
        }

        public AmendmentResource Visit(SetPropertyInheritedAmendment amendment, int index)
        {
            return new SetPropertyInheritedAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                PropertyName = amendment.PropertyName,
                Key = amendment.Key,
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(SetPropertyMultilingualAmendment amendment, int index)
        {
            throw new NotImplementedException();
        }

        public AmendmentResource Visit(SetCommentAmendment amendment, int index)
        {
            return new SetCommentAmendmentResource
            {
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Comment = amendment.Comment,
                Links = this.BuildLinks(amendment, index)
            };
        }

        public AmendmentResource Visit(ResetPropertyAmendment amendment, int index)
        {
            return new ResetPropertyAmendmentResource
            {
                Id = index,
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                PropertyName = amendment.PropertyName,
                Links = this.BuildLinks(amendment, index)
            };
        }

        private IEnumerable<LinkResource> BuildLinks(IAmendment amendment, int index)
        {
            var ownerPath = this.owner.Accept(new PathBuildingOwnerVisitor("components"));

            yield return new LinkResource
            {
                Rel = "self",
                Href = $"{ownerPath}&amendmentIndex={index}"
            };

            yield return new LinkResource
            {
                Rel = "subject",
                Href = amendment.SubjectPath.ToComponentPathString()
            };

            foreach (var affectedPath in amendment.AffectedPaths)
            {
                yield return new LinkResource
                {
                    Rel = "affected",
                    Href = affectedPath.ToComponentPathString()
                };
            }
        }
    }
}