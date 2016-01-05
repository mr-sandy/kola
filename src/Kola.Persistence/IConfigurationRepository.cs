namespace Kola.Persistence
{
    using Kola.Domain.Instances.Config;

    public interface IConfigurationRepository
    {
        IConfiguration Get(string path);
    }
}