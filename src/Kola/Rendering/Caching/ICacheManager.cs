namespace Kola.Rendering.Caching
{
    using Kola.Domain;
    using Kola.Rendering;

    public interface ICacheManager
    {
        void Record(IComponentInstance component, string value);
    }
}