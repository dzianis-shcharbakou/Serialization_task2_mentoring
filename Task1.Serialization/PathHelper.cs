using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1.Serialization
{
    public class PathHelper
    {
        public static string GetBooksXmlPath()
        {
            return Path.Combine(Environment.CurrentDirectory, "books.xml");
        }

        public static string GetNewCreatedBooksXmlPath()
        {
            return Path.Combine(Environment.CurrentDirectory, "newBooks.xml");
        }
    }
}
