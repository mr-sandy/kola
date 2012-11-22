
namespace Kola.Configuration
{
    internal class ParameterConfiguration
    {
        public ParameterConfiguration(string parameterName, string parameterType, string parameterValue)
        {
            this.ParameterName = parameterName;
            this.ParameterType = parameterType;
            this.ParameterValue = parameterValue;
        }

        public string ParameterName { get; private set; }

        public string ParameterType { get; private set; }

        public string ParameterValue { get; internal set; }
    }
}