namespace Unit.Tests.Domain.ComponentSpecifications
{
    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    [TestFixture]
    public class WhenBuildingAnAtomFromItsSpecification
    {
        private Atom atom;

        [SetUp]
        public void SetUp()
        {
            var atomSpecification = new AtomSpecification("atom 1");

            this.atom = atomSpecification.Create() as Atom;
        }

        [Test]
        public void ThereShouldBeAConfigEntryForAnAtom()
        {
            this.atom.Name.Should().Be("atom 1");
        }
    }
}