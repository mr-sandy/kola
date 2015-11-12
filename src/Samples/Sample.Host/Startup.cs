using Microsoft.Owin;

using Sample.Host;

[assembly: OwinStartup(typeof(Startup))]

namespace Sample.Host
{
    using Microsoft.Owin.Extensions;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}
