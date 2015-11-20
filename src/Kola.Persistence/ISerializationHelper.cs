namespace Kola.Persistence
{
    public interface ISerializationHelper
    {
        T Deserialize<T>(string path);

        void Serialize<T>(object o, string path);
    }
}