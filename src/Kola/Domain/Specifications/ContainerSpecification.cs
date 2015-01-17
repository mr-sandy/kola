namespace Kola.Domain.Specifications
{
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    public class ContainerSpecification : PluginComponentSpecification<Container>
    {
        public ContainerSpecification(string name)
            : base(name)
        {
        }

        public override Container Create()
        {
            return new Container(this.Name, this.CreateDefaultProperties());
        }

        public override TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}