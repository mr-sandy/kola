namespace Kola.Nancy.Modules
{
    using Kola.Domain.Composition;
    using Kola.ResourceBuilding;

    using global::Nancy;

    public class ParameterTypeModule : NancyModule
    {
        private readonly IParameterSpecificationLibrary parameterSpecificationLibrary;

        public ParameterTypeModule(IParameterSpecificationLibrary parameterSpecificationLibrary)
        {
            this.parameterSpecificationLibrary = parameterSpecificationLibrary;
            this.Get["/_kola/parameter-types", AcceptHeaderFilters.NotHtml] = p => this.GetParameterTypes();
            this.Get["/_kola/parameter-types/{name}", AcceptHeaderFilters.NotHtml] = p => this.GetParameterType(p.name);
        }

        private dynamic GetParameterTypes()
        {
            var parameterSpecifications = this.parameterSpecificationLibrary.FindAll();

            var resource = new ParameterTypeResourceBuilder().Build(parameterSpecifications);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json");
        }

        private dynamic GetParameterType(string name)
        {
            var parameterSpecification = this.parameterSpecificationLibrary.Find(name);

            var resource = new ParameterTypeResourceBuilder().Build(parameterSpecification);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json");
        }
    }
}