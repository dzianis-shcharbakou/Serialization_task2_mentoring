using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Task1.Serialization
{
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
    public class Catalog
    {
        [XmlAttribute("date", DataType = "date")]
        public DateTime Date { get; set; }
        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}
