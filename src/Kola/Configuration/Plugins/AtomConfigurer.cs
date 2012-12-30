
using Kola.Processing;

namespace Kola.Configuration.Plugins
{
    public class AtomConfigurer
    {
        private readonly AtomConfiguration atomConfiguration;

        internal AtomConfigurer(AtomConfiguration atomConfiguration)
        {
            this.atomConfiguration = atomConfiguration;
        }

        public AtomHandlerConfigurer WithHandler<T>(string viewName = "")
        {
            this.atomConfiguration.HandlerType = typeof(T);
            this.atomConfiguration.ViewName = viewName;
            return new AtomHandlerConfigurer(this.atomConfiguration);
        }

        public AtomHandlerConfigurer WithView(string viewName)
        {
            return this.WithHandler<DefaultHandler>(viewName);
        }
    }
}