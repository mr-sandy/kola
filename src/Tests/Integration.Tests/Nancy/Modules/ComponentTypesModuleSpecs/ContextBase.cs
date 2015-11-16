namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleSpecs
{
    using System;

    using global::Nancy.Responses.Negotiation;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Nancy;
    using Kola.Nancy.Modules;

    using global::Nancy.Testing;

    using Kola.Nancy.Processors;
    using Kola.Service.ResourceBuilding;

    using NUnit.Framework;

    using Rhino.Mocks;

    internal abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependencies(new object[] { this.ComponentLibrary });
                    with.ResponseProcessor<JsonProcessor>();
                    with.Module<ComponentTypeModule>();
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}