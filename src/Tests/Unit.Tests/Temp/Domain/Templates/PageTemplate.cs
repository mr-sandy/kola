namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class PageTemplate : ITemplate
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public PageTemplate(IEnumerable<IComponent> components)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public IInstance Build(IBuildContext buildContext)
        {
            var instances = this.components.Select(c => c.Build(buildContext)).ToList();

            return new PageInstance(instances);
        }
    }
}