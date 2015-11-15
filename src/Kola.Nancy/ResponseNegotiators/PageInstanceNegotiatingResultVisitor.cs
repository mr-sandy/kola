namespace Kola.Nancy.ResponseNegotiators
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class PageInstanceNegotiatingResultVisitor : NegotiatingResultVisitor<PageInstance>
    {
        public PageInstanceNegotiatingResultVisitor(NancyModule module)
            : base(module)
        {
        }

        public override Negotiator Visit(SuccessResult<PageInstance> result)
        {
            var response = this.Module.Negotiate.WithView("Page").WithModel(result.Data);

            return result.Data.RenderingInstructions.UseCache
                       ? response.WithHeader("Cache-Control", "public, max-age=600")
                       : response.WithHeader("Cache-Control", "no-cache");
        }
    }
}