using System.Text;
using System.Threading.Tasks;

namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Responses;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class PageResultProcessor : Processor<IResult<PageInstance>>
    {
        private readonly IResourceBuilder<PageInstance> builder;
        private const string ContentType = "external-account";

        private static readonly MediaRange JsonMediaRange = new MediaRange(MediaTypeBuilder.JsonType);
        private static readonly MediaRange VendorMediaRangeNoVersion = new MediaRange(MediaTypeBuilder.MediaType(ContentType));
        private static readonly MediaRange VendorMediaRangeVersion1 = new MediaRange(MediaTypeBuilder.MediaType(ContentType, versionNumber: 1));

        public PageResultProcessor(IResourceBuilder<PageInstance> builder, IEnumerable<ISerializer> serializers)
            : base(serializers, new[] { JsonMediaRange, VendorMediaRangeNoVersion, VendorMediaRangeVersion1 })
        {
            this.builder = builder;
        }

        public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<IResult<PageInstance>>)model;
            var responseBuilder = new ResponseBuildingResultVisitor<PageInstance>(this.builder, this.Serializer, VendorMediaRangeVersion1);

            return result.Accept(responseBuilder);
        }
    }

    public interface IResourceBuilder<T>
    {
        object Build(object data);
    }

    public static class MediaTypeBuilder
    {
        public static string CsvType
        {
            get { return "text/csv"; }
        }

        public static string JsonType
        {
            get { return "application/json"; }
        }

        public static string XmlType
        {
            get { return "application/xml"; }
        }

        public static string LinnMediaTypePrefix
        {
            get { return "application/vnd.linn."; }
        }

        public static string MediaType(string type, string system = null, int? versionNumber = null, string contentType = "json")
        {
            var systemString = string.IsNullOrEmpty(system) ? string.Empty : system + ".";
            var mediaType = string.Format("{0}{1}{2}+{3}", LinnMediaTypePrefix, systemString, type, contentType);

            if (versionNumber.HasValue)
            {
                mediaType += "; version=" + versionNumber.Value;
            }

            return mediaType;
        }
    }

    public class ResponseBuildingResultVisitor<T> : IResultVisitor<T, Response>
    {
        private readonly IResourceBuilder<T> builder;
        private readonly ISerializer serializer;
        private readonly string contentType;

        public ResponseBuildingResultVisitor(IResourceBuilder<T> builder, ISerializer serializer, string contentType)
        {
            this.builder = builder;
            this.serializer = serializer;
            this.contentType = contentType;
        }

        public Response Visit(SuccessResult<T> result)
        {
            return new JsonResponse(this.builder.Build(result.Data), this.serializer)
            {
                StatusCode = HttpStatusCode.OK,
                ContentType = this.contentType
            };
        }

        public Response Visit(UnauthorisedResult<T> result)
        {
            return new JsonResponse(new ErrorResource { errors = new[] { result.Message } }, this.serializer)
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
                ContentType = this.contentType
            };
        }

        public Response Visit(FailureResult<T> result)
        {
            return new JsonResponse(new ErrorResource { errors = new[] { result.Message } }, this.serializer)
            {
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
    public class ErrorResource
    {
        public IEnumerable<string> errors { get; set; }
    }

}
