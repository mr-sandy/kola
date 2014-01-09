namespace Kola.Configuration
{
    using Kola.Domain;

    public class AtomSpecification : PluginComponentSpecification
    {
        public AtomSpecification(string name)
            : base(name)
        {
        }

        public override IComponent Create()
        {
            return new Atom(this.Name);
        }
    }
}