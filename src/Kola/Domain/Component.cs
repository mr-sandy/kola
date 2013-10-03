namespace Kola.Domain
{
    using System.Diagnostics.CodeAnalysis;

    public class Component : Composite
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}