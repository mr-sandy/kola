namespace Kola.Rendering.Caching
{
    using Kola.Rendering;

    public interface ICacheManager
    {
        void Record(IComponent component, string value);
    }
}