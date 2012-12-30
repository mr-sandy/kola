
using System;
using System.Linq;
using Kola.Configuration;
using Kola.Configuration.Plugins;
using Kola.Model;
using Kola.Processing;
using NUnit.Framework;

namespace Unit.Tests.Configuration
{
    [TestFixture]
    public class WhenConfiguringAnAtom
    {
        private TestPluginBootstrapper bootstrapper;

        [SetUp]
        public void SetUp()
        {
            this.bootstrapper = new TestPluginBootstrapper();
        }

        [Test]
        public void ThereShouldBeAConfigEntryForAnAtom()
        {
            Assert.AreEqual(1, this.bootstrapper.PluginConfiguration.Atoms.Count()); 
        }

        [Test]
        public void TheAtomNameShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0);
            Assert.AreEqual("atom-1", config.AtomName);
        }

        [Test]
        public void TheViewNameShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0);
            Assert.AreEqual("viewName", config.ViewName);
        }

        [Test]
        public void TheHandlerShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0);
            Assert.AreEqual(typeof(TestHandler), config.HandlerType);
        }

        [Test]
        public void ThereShouldBeAConfigEntryForTheParameter()
        {
            Assert.AreEqual(1, this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0).Parameters.Count());
        }

        [Test]
        public void TheParameterNameShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0).Parameters.ElementAt(0);
            Assert.AreEqual("parameterName", config.ParameterName);
        }

        [Test]
        public void TheParameterTypeShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0).Parameters.ElementAt(0);
            Assert.AreEqual("parameterType", config.ParameterType);
        }

        [Test]
        public void TheParameterValueShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0).Parameters.ElementAt(0);
            Assert.AreEqual("parameterValue", config.ParameterValue);
        }

        [Test]
        public void TheCacheTypeShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0);
            Assert.AreEqual(CacheType.PerUser, config.CacheType);
        }

        [Test]
        public void TheCacheDurationShouldBeSet()
        {
            var config = this.bootstrapper.PluginConfiguration.Atoms.ElementAt(0);
            Assert.AreEqual(100, config.CacheDuration);
        }
    }

    internal class TestPluginBootstrapper :  PluginBootstrapper
    {
        public TestPluginBootstrapper()
        {
            this.Configure.Atom("atom-1")
                .WithHandler<TestHandler>("viewName")
                .WithParameter("parameterName", "parameterType", "parameterValue")
                .Cache.PerUser.For(100);
        }
    }

    internal class TestHandler : IHandler
    {
        public IRenderingResponse HandleRequest(IComponent component, RequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}
