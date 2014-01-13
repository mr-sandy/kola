namespace Kola.Domain
{
    public class AtomInstance : IComponentInstance
    {
        public AtomInstance(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public T Accept<T>(IComponentInstanceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}