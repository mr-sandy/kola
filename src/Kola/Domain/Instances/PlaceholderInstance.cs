namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public string Name
        {
            get { return string.Empty; } 
        }

        public T Accept<T>(IComponentInstanceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}