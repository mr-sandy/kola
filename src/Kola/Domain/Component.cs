namespace Kola.Domain
{
    public class Component
    {
        public Component(string name = "")
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}