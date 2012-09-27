using System;

namespace Kola.Configuration
{
    public class PluginConfiguration
    {
        private readonly Registry registration;

        public PluginConfiguration()
        {
            this.registration = new Registry(this);
        }

        public Registry Register
        {
            get { return registration; }
        }

        public void SetViewLocation(string location)
        {
            throw new NotImplementedException();
        }
    }
}
