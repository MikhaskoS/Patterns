using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Prototype.PrototypeFactory
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var stream = new MemoryStream())  // в оперативной памяти
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                object copy = formatter.Deserialize(stream);
                return (T)copy;
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}
