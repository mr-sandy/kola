namespace Kola.Domain.Specifications
{
    using Kola.Domain.Composition;

    public class AtomSpecification : PluginComponentSpecification<Atom>
    {
        public AtomSpecification(string name)
            : base(name)
        {
        }

        public override Atom Create()
        {
            return new Atom(this.Name, this.CreateDefaultProperties());
        }

        public override TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}