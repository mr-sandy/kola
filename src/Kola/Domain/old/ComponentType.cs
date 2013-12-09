namespace Kola.Domain
{
    public class ComponentType
    {
        public ComponentType(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}