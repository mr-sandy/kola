namespace Kola.Persistence
{
    using Kola.Domain.Instances.Context;

    public interface IContextRepository
    {
        IContext Get(string path);
    }
}