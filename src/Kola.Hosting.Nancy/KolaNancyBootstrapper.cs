using Nancy;
using Nancy.TinyIoc;

namespace Kola.Hosting.Nancy
{
    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            //TODO presumable there is a nicer pattern than this
            //ConfigurationBuilder.Build(Registry.Configuration);

            base.ConfigureApplicationContainer(container);

            //container.Register<IRazorConfiguration, MyRazorConfiguration>();

            //foreach (var viewLocation in Registry.Configuration.ViewLocations)
            //{
            //    ResourceViewLocationProvider.RootNamespaces.Add(viewLocation.Assembly, viewLocation.Location);
            //}

            //ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
        }

        //protected override NancyInternalConfiguration InternalConfiguration
        //{
        //    get
        //    {
        //        return
        //            NancyInternalConfiguration.WithOverrides(
        //                c => c.ViewLocationProvider = typeof(ResourceViewLocationProvider));
        //    }
        //}
    }
}