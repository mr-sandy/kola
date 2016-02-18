namespace Kola.Nancy.Processors
{
    using global::Nancy;

    using Kola.Service.Services.Results;

    public abstract class ResponseResultVisitor<T> : IResultVisitor<T, Response>
    {
        public virtual Response Visit(SuccessResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.OK);
        }

        public virtual Response Visit(UnauthorisedResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.Unauthorized);
        }

        public virtual Response Visit(NotFoundResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.NotFound);
        }

        public virtual Response Visit(CreatedResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.Created);
        }

        public virtual Response Visit(FailureResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.BadRequest);
        }

        public virtual Response Visit(ConflictResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.Conflict);
        }

        public virtual Response Visit(MovedPermanentlyResult<T> result)
        {
            return new Response()
                .WithStatusCode(HttpStatusCode.MovedPermanently)
                .WithHeader("Location", result.Location);

        }

        public virtual Response Visit(ForbiddenResult<T> result)
        {
            return new Response().WithStatusCode(HttpStatusCode.Forbidden);
        }
    }
}