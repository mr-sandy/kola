namespace Kola.Domain
{
    public class Component : Composite
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}