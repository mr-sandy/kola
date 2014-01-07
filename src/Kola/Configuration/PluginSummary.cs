namespace Kola.Configuration
{
    using System.Reflection;

    public class PluginSummary
    {
        public PluginSummary(Assembly assembly, string viewLocation)
        {
            this.Assembly = assembly;
            this.ViewLocation = viewLocation;
        }

        public Assembly Assembly { get; private set; }

        public string ViewLocation { get; private set; }
    }
}