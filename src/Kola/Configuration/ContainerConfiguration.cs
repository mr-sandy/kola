
namespace Kola.Configuration
{
    internal class ContainerConfiguration : ComponentConfiguration
    {
        public ContainerConfiguration(string containerName)
        {
            this.ContainerName = containerName;
        }

        public string ContainerName { get; private set; }
    }
}