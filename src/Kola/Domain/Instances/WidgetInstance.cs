namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    public class WidgetInstance : IComponentInstance
    {
        public WidgetInstance(string name, IEnumerable<IComponentInstance> children = null)
        {
            this.Name = name;
            this.Children = children;
        }

        public string Name { get; private set; }

        public IEnumerable<IComponentInstance> Children { get; private set; }

        public T Accept<T>(IComponentInstanceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}