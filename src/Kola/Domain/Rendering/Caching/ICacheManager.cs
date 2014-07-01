namespace Kola.Domain.Rendering.Caching
{
    using Kola.Domain.Instances;

    public interface ICacheManager
    {
        void Record(ComponentInstance component, string value);
    }
}