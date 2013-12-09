
namespace Kola.Configuration
{
    internal class ParameterTypeConfiguration
    {
        public ParameterTypeConfiguration(string parameterTypeName)
        {
            this.ParameterTypeName = parameterTypeName;
        }

        public string ParameterTypeName { get; private set; }

        public string DefaultValue { get; set; }

        public string EditorName { get; set; }
    }
}