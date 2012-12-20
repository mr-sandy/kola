using System.Reflection;

namespace Kola.Configuration.Ideas
{
    public class ViewLocation
    {

        public ViewLocation(Assembly assembly, string location)
        {
            Assembly = assembly;
            Location = location;
        }

        public Assembly Assembly { get; private set; }

        public string Location { get; private set; }
    }
}