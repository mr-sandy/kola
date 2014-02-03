namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class ContainerTemplate : IComponent, IContainer
    {
        private readonly List<IComponent> children = new List<IComponent>();

        public ContainerTemplate(IEnumerable<IComponent> children)
        {
            if (children != null)
            {
                this.children.AddRange(children);
            }
        }

        public IEnumerable<IComponent> Children
        {
            get { return this.children; }
        }

        public IInstance Build(IBuildContext buildContext)
        {
            var instances = this.children.Select(c => c.Build(buildContext)).ToList();
            
            return new ContainerInstance(instances);
        }
    }
}