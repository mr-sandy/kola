namespace Kola.Domain
{
    public abstract class Component
    {
        protected Component(string name = "")
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void Accept(IComponentVisitor visitor);
    }
}