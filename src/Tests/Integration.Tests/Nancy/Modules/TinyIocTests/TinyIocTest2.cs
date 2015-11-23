namespace Integration.Tests.Nancy.Modules.TinyIocTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using global::Nancy.TinyIoc;

    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;
    using Kola.Nancy.Modules;
    using Kola.Persistence;
    using Kola.Service;
    using Kola.Service.Services;

    using NUnit.Framework;

    public class TinyIocTest2
    {
        private TinyIoCContainer container;

        private IEnumerable<IDynamicSource> sources;

        [SetUp]
        public void SetUp()
        {
            this.container = new TinyIoCContainer();
            this.container.Register<IEnumerable<IDynamicSource>>(
                (c, o) =>
                    {
                        var sourceTypes = new[] { typeof(TestSource), typeof(TestSource) };
                        return sourceTypes.Select(type => c.Resolve<TestSource>());
                    });
            this.sources = this.container.Resolve<IEnumerable<IDynamicSource>>();
        }

        [Test]
        public void ShouldResolve()
        {
            this.sources.Should().NotBeNull();
        }

        [Test]
        public void ShouldHaveCount2()
        {
            this.sources.Should().HaveCount(2);
        }
    }

    internal class TestSource : IDynamicSource
    {
        public string Name { get; set; }

        public DynamicItem Lookup(string value, IEnumerable<IContextItem> context)
        {
            return new DynamicItem(value);
        }

        IEnumerable<DynamicItem> IDynamicSource.GetAllItems(IEnumerable<IContextItem> context)
        {
            throw new NotImplementedException();
        }
    }

}