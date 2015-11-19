namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Resources;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAComponent : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            //Create a template containing a container containing an atom
            var template = new Template(
                new[] { "test", "path" },
                new[] { new Container("container 1", Enumerable.Empty<Property>(), new[] { new Atom("atom 1") }) });

            this.ComponentLibrary.Stub(l => l.Lookup("atom 1")).Return(new AtomSpecification("atom 1"));
            this.ComponentLibrary.Stub(l => l.Lookup("container 1")).Return(new ContainerSpecification("container 1"));

            this.ContentRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(template);

            this.Response = this.Browser.Get("/_kola/templates/test/path/_components/0/0", with => with.Header("Accept", "application/json"));
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnAnAppropriateComponentResource()
        {
            this.Response.Body.DeserializeJson<AtomResource>().Should().NotBeNull();
        }

        [Test]
        public void ShouldReturnASelfLink()
        {
            this.Response.Body.DeserializeJson<AtomResource>().Links.Should().Contain(l => l.Rel == "self" && l.Href == "/_kola/templates/test/path/_components/0/0");
        }

        [Test]
        public void ShouldReturnTheComponentName()
        {
            this.Response.Body.DeserializeJson<AtomResource>().Name.Should().Be("atom 1");
        }
    }
}