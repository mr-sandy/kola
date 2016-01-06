namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Configuration;
    using Kola.Domain.Composition.Amendments;
    using Kola.Nancy.Extensions;
    using Kola.Nancy.Models;
    using Kola.Resources;
    using Kola.Service.DomainBuilding;
    using Kola.Service.Services;

    public class TemplateModule : NancyModule
    {
        private readonly ITemplateService templateService;

        private readonly IKolaConfigurationRegistry kolaConfigurationRegistry;

        public TemplateModule(ITemplateService templateService, IKolaConfigurationRegistry kolaConfigurationRegistry)
            : base("/_kola/templates")
        {
            this.templateService = templateService;
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;

            this.Get["/"] = p => this.GetTemplate();
            this.Put["/"] = p => this.PutTemplate();
            this.Get["/components"] = p => this.GetComponent();
            this.Get["/amendments"] = p => this.GetAmendments();
            this.Post["/amendments"] = p => this.PostAmendment();
            this.Put["/amendments"] = p => this.ApplyAmendments();
            this.Delete["/amendments"] = p => this.UndoAmendment();
        }

        private dynamic GetTemplate()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            return
                this.Negotiate.WithView("Application")
                    .WithMediaRangeModel("application/json", () => this.templateService.GetTemplate(path))
                    .WithMediaRangeModel("text/html", () => ApplicationModel.Build(this.kolaConfigurationRegistry));
        }

        private dynamic GetAmendments()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.GetAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetComponent()
        {
            var query = this.Bind<TemplateQuery>();
            var templatePath = query.TemplatePath.ParsePath();
            var componentPath = query.ComponentPath.ParseComponentPath();

            var result = this.templateService.GetComponent(templatePath, componentPath);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PutTemplate()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.CreateTemplate(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostAmendment()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();
            var amendment = this.BuildAmendment(query.AmendmentType);

            var result = this.templateService.AddAmendment(path, amendment);

            return this.Negotiate.WithModel(result);
        }

        private dynamic ApplyAmendments()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.ApplyAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic UndoAmendment()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.UndoAmendment(path);

            return this.Negotiate.WithModel(result);
        }

        private IAmendment BuildAmendment(string amendmentType)
        {
            var builder = new AmendmentDomainBuilder();

            switch (amendmentType)
            {
                case "addComponent":
                    return builder.Build(this.Bind<AddComponentAmendmentResource>());

                case "moveComponent":
                    return builder.Build(this.Bind<MoveComponentAmendmentResource>());

                case "removeComponent":
                    return builder.Build(this.Bind<RemoveComponentAmendmentResource>());

                case "duplicateComponent":
                    return builder.Build(this.Bind<DuplicateComponentAmendmentResource>());

                case "resetProperty":
                    return builder.Build(this.Bind<ResetPropertyAmendmentResource>());

                case "setPropertyFixed":
                    return builder.Build(this.Bind<SetPropertyFixedAmendmentResource>());

                case "setPropertyInherited":
                    return builder.Build(this.Bind<SetPropertyInheritedAmendmentResource>());

                case "setComment":
                    return builder.Build(this.Bind<SetCommentAmendmentResource>());

                default:
                    throw new KolaException("Unexpected amendment type");
            }
        }
    }
}