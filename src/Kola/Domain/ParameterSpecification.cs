namespace Kola.Domain
{
    public class ParameterSpecification
    {
        public ParameterSpecification(string parameterName, string parameterType, string parameterValue)
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