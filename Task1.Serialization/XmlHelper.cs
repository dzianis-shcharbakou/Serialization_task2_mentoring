using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Task1.Serialization
{
    public class XmlHelper
    {
        public void Serialize<T>(T entity)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(PathHelper.GetNewCreatedBooksXmlPath(), FileMode.Create))
            {
                using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "http://library.by/catalog");

                    serializer.Serialize(writer, entity, ns);
                }
            }
        }

        public T Deserialize<T>(string filePath) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader input = new StreamReader((Stream)fs))
                {
                    T result = serializer.Deserialize(input) as T;
                    return result;
                }
            }
        }
    }
}
