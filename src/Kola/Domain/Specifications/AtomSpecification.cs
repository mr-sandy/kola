namespace Kola.Domain.Specifications
{
    using System.Linq;

    using Kola.Domain.Templates;

    public class AtomSpecification : PluginComponentSpecification<AtomTemplate>
    {
        public AtomSpecification(string name)
            : base(name)
        {
        }

        public override AtomTemplate Create()
        {
            var parameters = this.Parameters.Select(p => p.Create());

            return new AtomTemplate(this.Name, parameters);
        }
    }
}