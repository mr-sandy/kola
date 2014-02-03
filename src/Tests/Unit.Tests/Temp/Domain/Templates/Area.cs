namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    public class Area : IContainer
    {
        private readonly List<IComponentTemplate> children = new List<IComponentTemplate>();

        public Area(IEnumerable<IComponentTemplate> children)
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
    }
}
