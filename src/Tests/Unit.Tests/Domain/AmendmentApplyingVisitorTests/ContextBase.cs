namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected AmendmentApplyingVisitor Visitor { get; private set; }

        protected PageTemplate Template { get; private set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; private set; }

        protected IComponentSpecification<IComponentTemplate> ComponentSpecification { get; private set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.Template = new PageTemplate(new[] { "path" });

            this.ComponentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();

            this.ComponentSpecification = MockRepository.GenerateStub<IComponentSpecification<IComponentTemplate>>();

            this.ComponentLibrary.Stub(l => l.Lookup(Arg<string>.Is.Anything)).Return(this.ComponentSpecification);
            
            this.Visitor = new AmendmentApplyingVisitor(this.Template, this.ComponentLibrary);
        }        
    }
}