namespace Kola.Domain.Specifications
{
    using System.Linq;

    using Kola.Domain.Templates;

    public class ContainerSpecification : PluginComponentSpecification<ContainerTemplate>
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override ContainerTemplate Create()
        {
            var parameters = this.Parameters.Select(p => p.Create());

            return new ContainerTemplate(this.Name, parameters);
        }
    }
}