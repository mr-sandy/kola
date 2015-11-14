namespace Kola.Nancy.Modules
{
    using System;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Service.Services.Results;

    public abstract class NegotiatingResultVisitor<T> : IResultVisitor<T, Negotiator>
    {
        protected readonly NancyModule Module;

        protected NegotiatingResultVisitor(NancyModule module)
        {
            this.Module = module;
        }

        public abstract Negotiator Visit(SuccessResult<T> result);

        public Negotiator Visit(UnauthorisedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Negotiator Visit(NotFoundResult<T> result)
        {
            return this.Module.Negotiate.WithView("Error").WithStatusCode(HttpStatusCode.NotFound);
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