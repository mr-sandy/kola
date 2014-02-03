namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    public class Area : IContainer
    {
        private readonly List<IComponent> children = new List<IComponent>();

        public Area(IEnumerable<IComponent> children)
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
    }
}
