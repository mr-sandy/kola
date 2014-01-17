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
            atomSpecification.AddParameter(new ParameterSpecification("parameter 1 name", "parameter 1 type"));

            this.atom = atomSpecification.Create();
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectName()
        {
            this.atom.Name.Should().Be("atom 1");
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectNumberOfParameters()
        {
            this.atom.Parameters.Should().HaveCount(1);
        }

        // TODO {SC} COntinue from here
    }
}