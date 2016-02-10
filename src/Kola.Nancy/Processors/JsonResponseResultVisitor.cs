namespace Kola.Nancy.Processors
{
    using global::Nancy;
    using global::Nancy.Responses;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

    public class JsonResponseResultVisitor<T> : ResponseResultVisitor<T>
    {
        private readonly IResourceBuilder<T> builder;
        private readonly ISerializer serializer;

        public JsonResponseResultVisitor(IResourceBuilder<T> builder, ISerializer serializer)
        {
            this.builder = builder;
            this.serializer = serializer;
        }

        public override Response Visit(SuccessResult<T> result)
        {
            return new JsonResponse(this.builder.Build(result.Data), this.serializer)
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("application/json");
        }

        public override Response Visit(CreatedResult<T> result)
        {
            return new JsonResponse(this.builder.Build(result.Data), this.serializer)
                    .WithStatusCode(HttpStatusCode.Created)
                    .WithContentType("application/json")
                    .WithHeader("location", this.builder.Location(result.Data));
        }

        public override Response Visit(FailureResult<T> result)
        {
            return new JsonResponse(new { errors = new[] { result.Message } }, this.serializer)
                    .WithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}