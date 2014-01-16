namespace Kola.Domain
{
    public class ParameterSpecification
    {
        public ParameterSpecification(string parameterName, string parameterType)
        {
            this.ParameterName = parameterName;
            this.ParameterType = parameterType;
        }

        public string ParameterName { get; private set; }

        public string ParameterType { get; private set; }
    }
}