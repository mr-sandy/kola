namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;

    public class AtomSpecification : PluginComponentSpecification<AtomTemplate>
    {
        public AtomSpecification(string name)
            : base(name)
        {
        }

        public override AtomTemplate Create()
        {
            return new AtomTemplate(this.Name, this.CreateParameters());
        }
    }
}