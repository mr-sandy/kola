namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class PageTemplate
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public PageTemplate(IEnumerable<IComponentTemplate> components)
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

        public PageInstance Build(IBuildContext buildContext)
        {
            var instances = this.components.Select(c => c.Build(buildContext)).ToList();

            return new PageInstance(instances);
        }
    }
}