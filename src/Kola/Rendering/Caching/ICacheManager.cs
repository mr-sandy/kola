namespace Kola.Rendering.Caching
{
    using Kola.Domain;
    using Kola.Rendering;

    public interface ICacheManager
    {
        void Record(IComponent component, string value);
    }
}