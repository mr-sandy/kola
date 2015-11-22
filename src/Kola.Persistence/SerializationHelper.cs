namespace Kola.Persistence
{
    using System.Configuration;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class SerializationHelper : ISerializationHelper
    {
        private readonly string root;

        public SerializationHelper(string root)
        {
            this.root = root;
        }

        public void Serialize<T>(object obj, string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);

            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlWriterSettings { Indent = true };

            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                var xmlWriter = XmlWriter.Create(fs, settings);
                serializer.Serialize(xmlWriter, obj);
                xmlWriter.Flush();
                fs.Close();
            }
        }

        public T Deserialize<T>(string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);

            var serializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var xmlReader = XmlReader.Create(fs);
                var t = (T)serializer.Deserialize(xmlReader);
                fs.Close();

                return t;
            }
        }
    }
}
