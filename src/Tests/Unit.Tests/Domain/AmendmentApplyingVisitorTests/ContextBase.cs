namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests
{
    using Kola.Domain;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected AmendmentApplyingVisitor Visitor { get; private set; }

        protected Template Template { get; private set; }

        protected IComponentLibrary ComponentLibrary { get; private set; }

        protected IComponentSpecification ComponentSpecification { get; private set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.Template = new Template(new[] { "path" });

            this.ComponentLibrary = MockRepository.GenerateStub<IComponentLibrary>();

            this.ComponentSpecification = MockRepository.GenerateStub<IComponentSpecification>();

            this.ComponentLibrary.Stub(l => l.Lookup(Arg<string>.Is.Anything)).Return(this.ComponentSpecification);
            
            this.Visitor = new AmendmentApplyingVisitor(this.Template, this.ComponentLibrary);
        }        
    }
}