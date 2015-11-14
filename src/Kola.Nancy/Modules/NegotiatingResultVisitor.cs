namespace Kola.Nancy.Modules
{
    using System;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class NegotiatingResultVisitor<T> : IResultVisitor<T, Negotiator>
    {
        private readonly NancyModule module;

        private readonly string viewName;

        private readonly bool preview;

        public NegotiatingResultVisitor(NancyModule module, string viewName, bool preview)
        {
            this.module = module;
            this.viewName = viewName;
            this.preview = preview;
        }

        public Negotiator Visit(SuccessResult<T> result)
        {
            var response = this.module.Negotiate.WithView(this.viewName).WithModel(result.Data);

            return (this.preview) 
                ? response.WithHeader("Cache-Control", "no-cache")
                : response.WithHeader("Cache-Control", "public, max-age=600");
        }

        public Negotiator Visit(UnauthorisedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Negotiator Visit(NotFoundResult<T> result)
        {
            return this.module.Negotiate.WithView("Error").WithStatusCode(HttpStatusCode.NotFound);
        }

        public Negotiator Visit(CreatedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Negotiator Visit(FailureResult<T> result)
        {
            throw new NotImplementedException();
        }
    }
}