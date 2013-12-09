namespace Kola.Configuration.Ideas
{
    using System.Reflection;

    public class ViewLocation
    {

        public ViewLocation(Assembly assembly, string location)
        {
            this.Assembly = assembly;
            this.Location = location;
        }

        public Assembly Assembly { get; private set; }

        public string Location { get; private set; }
    }
}