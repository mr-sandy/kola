
namespace Kola.Configuration.Plugins
{
    public class AtomHandlerConfigurer
    {
        public AtomHandlerConfigurer WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            return this;
        }

        public CacheConfiguration Cache
        {
            get { return null; }
        }
    }
}