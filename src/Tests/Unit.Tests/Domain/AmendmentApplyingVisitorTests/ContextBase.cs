namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected AmendmentApplyingVisitor Visitor { get; private set; }

        protected Template Template { get; private set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; private set; }

        protected IParameterisedComponentSpecification<IParameterisedComponent> ComponentSpecification { get; private set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.Template = new Template(new[] { "path" });

            this.ComponentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();

            this.ComponentSpecification = MockRepository.GenerateStub<IParameterisedComponentSpecification<IParameterisedComponent>>();

            this.ComponentLibrary.Stub(l => l.Lookup(Arg<string>.Is.Anything)).Return(this.ComponentSpecification);
            
            this.Visitor = new AmendmentApplyingVisitor(this.Template, this.ComponentLibrary);
        }        
    }
}