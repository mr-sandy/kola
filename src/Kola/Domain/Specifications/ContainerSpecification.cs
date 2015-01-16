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
            var properties = this.Properties.Select(p => p.Create()).Where(p => p.Value is FixedPropertyValue && !string.IsNullOrEmpty(((FixedPropertyValue)p.Value).Value)).ToList();
            return new Container(this.Name, properties);
        }

        public override TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}