using Kola.Nancy.Modules;
using Nancy.Testing;
using NUnit.Framework;
using Rhino.Mocks;
using Kola.Persistence;

namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }
        protected BrowserResponse Response { get; set; }
        protected ITemplateRepository TemplateRepository { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.TemplateRepository = MockRepository.GenerateMock<ITemplateRepository>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependencies(this.TemplateRepository);
                    with.Module<TemplatesModule>();
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}