namespace Unit.Tests.Domain.ComponentSpecifications
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAnAtomFromItsSpecification
    {
        private AtomTemplate atom;

        [SetUp]
        public void SetUp()
        {
            var atomSpecification = new AtomSpecification("atom 1");
            atomSpecification.AddParameter(new ParameterSpecification("parameter 1 name", "parameter 1 type"));
            atomSpecification.AddParameter(new ParameterSpecification("parameter 2 name", "parameter 2 type", "default value"));

            this.atom = atomSpecification.Create();
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectName()
        {
            this.atom.Name.Should().Be("atom 1");
        }

        [Test]
        public void TheAtomShouldContainOnlyParametersWithDefaultValues()
        {
            this.atom.Parameters.Should().HaveCount(1);
        }

        [Test]
        public void TheParaetersDefaultValuesShouldBeFixed()
        {
            this.atom.Parameters.Single().Value.Should().BeOfType<FixedParameterValue>();
        }

        [Test]
        public void TheParaetersDefaultValuesShouldBeSet()
        {
            var value = this.atom.Parameters.Single().Value as FixedParameterValue;
            value.Value.Should().Be("default value");
        }
    }
}