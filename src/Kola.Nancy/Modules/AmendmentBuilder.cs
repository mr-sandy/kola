namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;
    using Kola.Service.DomainBuilding;

    internal class AmendmentBuilder
    {
        private readonly NancyModule module;

        public AmendmentBuilder(NancyModule module)
        {
            this.module = module;
        }

        public IAmendment BuildAmendment(string amendmentType)
        {
            var builder = new AmendmentDomainBuilder();

            switch (amendmentType)
            {
                case "addComponent":
                    return builder.Build(this.module.Bind<AddComponentAmendmentResource>());

                case "moveComponent":
                    return builder.Build(this.module.Bind<MoveComponentAmendmentResource>());

                case "removeComponent":
                    return builder.Build(this.module.Bind<RemoveComponentAmendmentResource>());

                case "duplicateComponent":
                    return builder.Build(this.module.Bind<DuplicateComponentAmendmentResource>());

                case "resetProperty":
                    return builder.Build(this.module.Bind<ResetPropertyAmendmentResource>());

                case "setPropertyFixed":
                    return builder.Build(this.module.Bind<SetPropertyFixedAmendmentResource>());

                case "setPropertyInherited":
                    return builder.Build(this.module.Bind<SetPropertyInheritedAmendmentResource>());

                case "setComment":
                    return builder.Build(this.module.Bind<SetCommentAmendmentResource>());

                default:
                    throw new KolaException("Unexpected amendment type");
            }
        }

    }
}