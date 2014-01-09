namespace Kola.Configuration
{
    using Kola.Domain;

    public class ContainerSpecification : PluginComponentSpecification
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override IComponent Create()
        {
            return new Container(this.Name);
        }
    }
}