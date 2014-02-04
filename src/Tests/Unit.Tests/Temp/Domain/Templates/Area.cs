namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    public class Area : IComponentCollection
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public Area(IEnumerable<IComponentTemplate> components)
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
    }
}
