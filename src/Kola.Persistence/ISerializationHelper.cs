namespace Kola.Persistence
{
    public interface ISerializationHelper
    {
        T Deserialize<T>(string relativePath);

        void Serialize<T>(object obj, string relativePath);
    }
}