namespace Kola.Rendering.Caching
{
    using Kola.Domain.Instances;

    public interface ICacheManager
    {
        void Record(IComponentInstance component, string value);
    }
}