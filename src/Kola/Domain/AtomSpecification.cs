namespace Kola.Domain
{
    using System.Linq;

    public class AtomSpecification : PluginComponentSpecification<Atom>
    {
        public AtomSpecification(string name)
            : base(name)
        {
        }

        public override Atom Create()
        {
            var parameters = this.Parameters.Select(p => p.Create());

            return new Atom(this.Name, parameters);
        }
    }
}