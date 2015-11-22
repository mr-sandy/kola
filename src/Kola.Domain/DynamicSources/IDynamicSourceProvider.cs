namespace Kola.Domain.DynamicSources
{
    public interface IDynamicSourceProvider
    {
        IDynamicSource Get(string sourceName);
    }

    public class DynamicSourceProvider : IDynamicSourceProvider
    {
        public IDynamicSource Get(string sourceName)
        {
            return null;
        }
    }
}