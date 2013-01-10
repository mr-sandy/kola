using System;
using System.Reflection;
using Kola.Configuration.Ideas;
using Kola.Processing;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            //This shouldn't be an instance - needs to be a factory?
            var kolaHostConfiguration = new KolaBootstrapper().Bootstrap(new TinyIoCObjectFactory(container));

            foreach (var viewLocation in kolaHostConfiguration.ViewLocations)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(viewLocation.Assembly, viewLocation.Location);
            }

            ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Hosting.Nancy");
            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
            ResourceViewLocationProvider.Ignore.Add(Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));

            base.ConfigureApplicationContainer(container);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(c => c.ViewLocationProvider = typeof(ResourceViewLocationProvider));
            }
        }
    }

    public class NancyRazorViewHelper<T> : IViewHelper
    {
        private readonly HtmlHelpers<T> htmlHelpers;

        public NancyRazorViewHelper(HtmlHelpers<T> htmlHelpers)
        {
            this.htmlHelpers = htmlHelpers;
        }

        public string RenderPartial<TModel>(string viewName, TModel model)
        {
            return this.htmlHelpers.Partial(viewName, model).ToHtmlString();
        }
    }

    public class TinyIoCObjectFactory : IObjectFactory
    {
        private readonly TinyIoCContainer container;

        public TinyIoCObjectFactory(TinyIoCContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>(Type type)
        {
            return (T)this.container.Resolve(type);
        }
    }
}