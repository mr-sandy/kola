namespace Kola.Nancy.Processors
{
    using global::Nancy;
    using global::Nancy.Responses;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

    public class ResponseBuildingResultVisitor<T> : IResultVisitor<T, Response>
    {
        private readonly IResourceBuilder<T> builder;
        private readonly ISerializer serializer;

        public ResponseBuildingResultVisitor(IResourceBuilder<T> builder, ISerializer serializer)
        {
            this.builder = builder;
            this.serializer = serializer;
        }

        public Response Visit(SuccessResult<T> result)
        {
            return new JsonResponse(this.builder.Build(result.Data), this.serializer)
                       {
                           StatusCode = HttpStatusCode.OK,
                           ContentType = "application/json"
                       };
        }

        public Response Visit(UnauthorisedResult<T> result)
        {
            return new JsonResponse(new { errors = new[] { result.Message } }, this.serializer)
                       {
                           StatusCode = HttpStatusCode.Unauthorized
                       };
        }

        public Response Visit(NotFoundResult<T> result)
        {
            return new NotFoundResponse();
        }

        public Response Visit(CreatedResult<T> result)
        {
            return new JsonResponse(this.builder.Build(result.Data), this.serializer)
                       {
                           StatusCode = HttpStatusCode.Created,
                           ContentType = "application/json"
                       };
        }

        public Response Visit(FailureResult<T> result)
        {
            return new JsonResponse(new { errors = new[] { result.Message } }, this.serializer)
                       {
                           StatusCode = HttpStatusCode.BadRequest
                       };
        }
    }
}