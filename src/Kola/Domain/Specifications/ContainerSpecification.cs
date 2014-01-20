namespace Kola.Domain.Specifications
{
    using System.Linq;

    using Kola.Domain.Templates;

    public class ContainerSpecification : PluginComponentSpecification<Container>
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override Container Create()
        {
            var parameters = this.Parameters.Select(p => p.Create());

            return new Container(this.Name, parameters);
        }
    }
}