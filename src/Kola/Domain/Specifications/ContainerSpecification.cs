namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;

    public class ContainerSpecification : PluginComponentSpecification<ContainerTemplate>
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override ContainerTemplate Create()
        {
            return new ContainerTemplate(this.Name, this.CreateParameters());
        }
    }
}