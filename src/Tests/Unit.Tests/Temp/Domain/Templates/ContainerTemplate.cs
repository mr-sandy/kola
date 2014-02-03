namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class ContainerTemplate : IComponentTemplate, IContainer
    {
        private readonly List<IComponentTemplate> children = new List<IComponentTemplate>();

        public ContainerTemplate(IEnumerable<IComponentTemplate> children)
        {
            if (children != null)
            {
                this.children.AddRange(children);
            }
        }

        public IEnumerable<IComponentTemplate> Children
        {
            get { return this.children; }
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var instances = this.children.Select(c => c.Build(buildContext)).ToList();
            
            return new ContainerInstance(instances);
        }
    }
}