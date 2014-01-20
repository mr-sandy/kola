namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;

    public class ContainerSpecification : PluginComponentSpecification<Container>
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override Container Create()
        {
            return new Container(this.Name);
        }
    }
}