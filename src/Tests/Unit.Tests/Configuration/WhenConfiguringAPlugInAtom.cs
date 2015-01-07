
using System;
using System.Linq;
using Kola.Configuration;
using Kola.Domain.Rendering;
using NUnit.Framework;

namespace Unit.Tests.Configuration
{
    using Kola.Configuration.Plugins;
    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Domain.Specifications;

    [TestFixture]
    public class WhenConfiguringAnAtom
    {
        private TestPluginConfiguration configuration;

        [SetUp]
        public void SetUp()
        {
            this.configuration = new TestPluginConfiguration();
        }

        [Test]
        public void ThereShouldBeAConfigEntryForAnAtom()
        {
            Assert.AreEqual(1, this.configuration.ComponentTypeSpecifications.Count()); 
        }

        [Test]
        public void TheAtomNameShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0);
            Assert.AreEqual("atom-1", config.Name);
        }

        [Test]
        public void TheViewNameShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0);
            Assert.AreEqual("viewName", config.ViewName);
        }

        [Test]
        public void TheHandlerShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0);
            Assert.AreEqual(typeof(TestHandler), config.RendererType);
        }

        [Test]
        public void ThereShouldBeAConfigEntryForTheParameter()
        {
            Assert.AreEqual(1, this.configuration.ComponentTypeSpecifications.ElementAt(0).Parameters.Count());
        }

        [Test]
        public void TheParameterNameShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0).Parameters.ElementAt(0);
            Assert.AreEqual("parameterName", config.Name);
        }

        [Test]
        public void TheParameterTypeShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0).Parameters.ElementAt(0);
            Assert.AreEqual("parameterType", config.Type);
        }

        [Test]
        public void TheCacheTypeShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0);
            Assert.AreEqual(CacheType.Cache, config.CacheType);
        }

        [Test]
        public void TheCacheDurationShouldBeSet()
        {
            var config = this.configuration.ComponentTypeSpecifications.ElementAt(0);
            Assert.AreEqual(100, config.CacheDuration);
        }
    }

    internal class TestPluginConfiguration :  PluginConfiguration
    {
        public TestPluginConfiguration()
        {
            this.Configure.Container("atom-1")
                .WithRenderer<TestHandler>("viewName")
                .WithParameter("parameterName", "parameterType")
                .Cache.Cache.For(100);
        }
    }

    internal class TestHandler : IRenderer<AtomInstance>
    {
        public IResult Render(AtomInstance component)
        {
            throw new NotImplementedException();
        }
    }
}
