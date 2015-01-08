
namespace Kola.Configuration
{
    public class PropertyTypeSpecification
    {
        public PropertyTypeSpecification(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string DefaultValue { get; set; }

        public string EditorName { get; set; }
    }
}