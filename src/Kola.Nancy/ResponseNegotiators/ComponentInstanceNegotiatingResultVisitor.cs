namespace Kola.Nancy.ResponseNegotiators
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class ComponentInstanceNegotiatingResultVisitor : NegotiatingResultVisitor<ComponentInstance>
    {
        public ComponentInstanceNegotiatingResultVisitor(NancyModule module)
            : base(module)
        {
        }

        public override Negotiator Visit(SuccessResult<ComponentInstance> result)
        {
            return this.Module.Negotiate.WithView("Fragment").WithModel(result.Data);
        }
    }
}