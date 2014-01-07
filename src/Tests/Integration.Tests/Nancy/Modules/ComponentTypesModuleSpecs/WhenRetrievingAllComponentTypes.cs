namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Configuration;
    using Kola.Editing;
    using Kola.Resources;

    using global::Nancy;
    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    internal class WhenRetrievingAllComponentTypes : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var components = new[]
                {
                    new ComponentSpecification("Component A"), 
                    new ComponentSpecification("Component B") 
                };

            this.ComponentTypeRepository.Stub(r => r.FindAll()).Return(components);
            this.Response = this.Browser.Get("/_kola/component-types", b => b.Header("Accept", "application/json"));
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnTwoComponentTypeResources()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<ComponentTypeResource>>();
            resources.Should().HaveCount(2);
        }

        [Test]
        public void EachResourceShouldHaveASelfLink()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<ComponentTypeResource>>();

            foreach (var resource in resources)
            {
                resource.Links.Should().Contain(l => l.Rel == "self");
            }
        }

        [Test]
        public void FirstResourceShouldHaveValidHrefValue()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<ComponentTypeResource>>();

            resources.First().Links.Where(l => l.Rel == "self").Single().Href.Should().Be("/_kola/component-types/component-a");
        }

        [Test]
        public void SecondResourceShouldHaveValidHrefValue()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<ComponentTypeResource>>();

            resources.ElementAt(1).Links.Where(l => l.Rel == "self").Single().Href.Should().Be("/_kola/component-types/component-b");
        }
    }
}
