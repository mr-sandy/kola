namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.Responses;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class ResponseBuildingGetPageResultVisitor : IResultVisitor<PageInstance, Negotiator>
    {
        private readonly NancyModule module;

        public ResponseBuildingGetPageResultVisitor(NancyModule module)
        {
            this.module = module;
        }

        public Negotiator Visit(SuccessResult<PageInstance> result)
        {
            return module.Negotiate.WithView("Page").WithModel(result.Data);
        }

        public Negotiator Visit(UnauthorisedResult<PageInstance> result)
        {
            throw new System.NotImplementedException();
        }

        public Negotiator Visit(NotFoundResult<PageInstance> result)
        {
            throw new System.NotImplementedException();
        }

        public Negotiator Visit(CreatedResult<PageInstance> result)
        {
            throw new System.NotImplementedException();
        }

        public Negotiator Visit(FailureResult<PageInstance> result)
        {
            throw new System.NotImplementedException();
        }
    }
}