namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Specifications;
    using Kola.Resources;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingAmendments : ContextBase
    {
        private Template template;

        [SetUp]
        public void SetUp()
        {
            this.template = new Template(
                new[] { "test", "path" },
                null,
                new[] { new AddComponentAmendment(new[] { 0 }, "atom name") });

            this.ContentRepository.Stub(r => r.GetTemplate(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(this.template);

            this.ComponentLibrary.Stub(l => l.Lookup("atom name")).Return(new AtomSpecification("atom name"));

            this.Response = this.Browser.Put(
                "/_kola/templates/amendments",
                with =>
                    {
                        with.Query("templatePath", "/test/path");
                        with.Header("Accept", "application/json");
                    });
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnAListOfAmendmentsResource()
        {
            this.Response.Body.DeserializeJson<IEnumerable<AmendmentResource>>().Should().NotBeNull();
        }

        [Test]
        public void ShouldReturnAnEmptyListOfAmendmentsResource()
        {
            this.Response.Body.DeserializeJson<IEnumerable<AmendmentResource>>().Should().HaveCount(0);
        }

        [Test]
        public void ShouldClearTheAmendmentsInTheTemplate()
        {
            this.template.Amendments.Should().HaveCount(0);
        }

        [Test]
        public void ShouldAddAComponentToTheTemplate()
        {
            this.template.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldUpdateTemplateToRepository()
        {
            this.ContentRepository.AssertWasCalled(r => r.Update(Arg<Template>.Is.Anything));
        }
    }
}