namespace Kola.Processing.Caching
{
    using Kola.Processing;

    public interface ICacheManager
    {
        void Record(IComponent component, string value);
    }
}