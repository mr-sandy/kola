namespace Sample.Host
{
    using System.Threading.Tasks;

    using Microsoft.Owin;

    public class StatusCodeLoggingMiddleware : OwinMiddleware
    {
        public StatusCodeLoggingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            System.Diagnostics.Debug.WriteLine("before = " + context.Response.StatusCode + " " + context.Response.ReasonPhrase);
            await this.Next.Invoke(context);
            System.Diagnostics.Debug.WriteLine("after = " + context.Response.StatusCode + " " + context.Response.ReasonPhrase);
        }
    }
}