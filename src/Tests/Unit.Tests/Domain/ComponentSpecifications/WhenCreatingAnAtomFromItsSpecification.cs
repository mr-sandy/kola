namespace Unit.Tests.Domain.ComponentSpecifications
{
    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAnAtomFromItsSpecification
    {
        private Atom atom;

        [SetUp]
        public void SetUp()
        {
            var atomSpecification = new AtomSpecification("atom 1");
            atomSpecification.AddParameter(new ParameterSpecification("parameter 1 name", "parameter 1 type"));
            atomSpecification.AddParameter(new ParameterSpecification("parameter 2 name", "parameter 2 type"));

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
            this.atom.Parameters.Should().HaveCount(2);
        }

        // TODO {SC} COntinue from here
    }
}