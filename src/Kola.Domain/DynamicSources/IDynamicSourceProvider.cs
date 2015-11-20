namespace Kola.Domain.DynamicSources
{
    public interface IDynamicSourceProvider
    {
        IDynamicSource Get(string sourceName);
    }
}