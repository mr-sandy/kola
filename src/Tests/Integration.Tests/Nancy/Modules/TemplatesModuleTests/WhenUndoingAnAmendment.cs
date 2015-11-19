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

    public class WhenUndoingAnAmendment : ContextBase
    {
        private Template template;

        [SetUp]
        public void SetUp()
        {
            this.template = new Template(new[] { "test", "path" }, null, new[] { new AddComponentAmendment(new[] { 0 }, "atom name") });

            this.ContentRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(this.template);

            this.ComponentLibrary.Stub(l => l.Lookup("atom name")).Return(new AtomSpecification("atom name"));

            this.Response = this.Browser.Post("/_kola/templates/test/path/_amendments/undo", with => { with.Header("Accept", "application/json"); });
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnAnUndoAmendmentResource()
        {
            this.Response.Body.DeserializeJson<UndoAmendmentResource>().Should().NotBeNull();
        }

        [Test]
        public void ShouldReturnAnEmptyListOfAmendments()
        {
            this.Response.Body.DeserializeJson<UndoAmendmentResource>().Amendments.Should().HaveCount(0);
        }

        [Test]
        public void ShouldIncludeASelfLink()
        {
            this.Response.Body.DeserializeJson<UndoAmendmentResource>().Links.Should().Contain(l => l.Rel == "self" && l.Href == "/_kola/templates/test/path/_amendments");
        }

        [Test]
        public void ShouldClearTheAmendmentsInTheTemplate()
        {
            this.template.Amendments.Should().HaveCount(0);
        }

        [Test]
        public void ShouldNotAddAComponentToTheTemplate()
        {
            this.template.Components.Should().HaveCount(0);
        }

    }
}