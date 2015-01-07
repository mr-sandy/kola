
namespace Kola.Configuration
{
    public class ParameterTypeSpecification
    {
        public ParameterTypeSpecification(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string DefaultValue { get; set; }

        public string EditorName { get; set; }
    }
}