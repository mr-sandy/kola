namespace Unit.Tests.Domain.ComponentSpecifications
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAnAtomFromItsSpecification
    {
        private Atom atom;

        [SetUp]
        public void SetUp()
        {
            var atomSpecification = new AtomSpecification("atom 1");
            atomSpecification.AddProperty(new PropertySpecification("property 1 name", "property 1 type"));
            atomSpecification.AddProperty(new PropertySpecification("property 2 name", "property 2 type"));

            this.atom = atomSpecification.Create();
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectName()
        {
            this.atom.Name.Should().Be("atom 1");
        }

        [Test]
        public void TheAtomShouldNotYetContainAnyParamters()
        {
            this.atom.Properties.Should().HaveCount(0);
        }
    }
}