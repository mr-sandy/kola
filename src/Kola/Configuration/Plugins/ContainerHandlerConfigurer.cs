
namespace Kola.Configuration.Plugins
{
    public class ContainerHandlerConfigurer
    {
        private readonly ContainerConfiguration containerConfiguration;

        internal ContainerHandlerConfigurer(ContainerConfiguration containerConfiguration)
        {
            this.containerConfiguration = containerConfiguration;
        }

        public ContainerHandlerConfigurer WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            this.containerConfiguration.ConfigureParameter(parameterName, parameterType, parameterValue);
            return this;
        }
    }
}