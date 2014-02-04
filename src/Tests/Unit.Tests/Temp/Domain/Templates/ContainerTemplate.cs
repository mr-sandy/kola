namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class ContainerTemplate : IComponentTemplate, IComponentCollection
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public ContainerTemplate(IEnumerable<IComponentTemplate> components)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public IEnumerable<IComponentTemplate> Components
        {
            get { return this.components; }
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var instances = this.components.Select(c => c.Build(buildContext)).ToList();
            
            return new ContainerInstance(instances);
        }
    }
}