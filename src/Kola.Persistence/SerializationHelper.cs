namespace Kola.Persistence
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class SerializationHelper : ISerializationHelper
    {
        public void Serialize<T>(object o, string path) 
        {
            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlWriterSettings
                {
                    Indent = true
                };
            using (var fs = new FileStream(path, FileMode.Create))
            {
                var xmlWriter = XmlWriter.Create(fs, settings);
                serializer.Serialize(xmlWriter, o);
                xmlWriter.Flush();
                fs.Close();
            }
        }

        public T Deserialize<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var xmlReader = XmlReader.Create(fs);
                var t = (T)serializer.Deserialize(xmlReader);
                fs.Close();

                return t;
            }
        }
    }
}
