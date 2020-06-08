using NUnit.Framework;
using NUnit.Framework.Constraints;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Constraints;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task1.Serialization.Test
{
    public class SerializerTest
    {
        [Test]
        [Order(1)]
        public void DeserializationTest()
        {
            XmlHelper serializer = new XmlHelper();

            var path = PathHelper.GetBooksXmlPath();

            var result = serializer.Deserialize<Catalog>(path);

            Assert.That(result, Is.XmlSerializable);
        }

        [Test]
        [Order(3)]
        public void SerializationBookXmlToNewBookXmlTest()
        {
            XmlHelper serializer = new XmlHelper();

            var path = PathHelper.GetBooksXmlPath();
            var entity = serializer.Deserialize<Catalog>(path);

            serializer.Serialize<Catalog>(entity);

            // Assertion
            Org.XmlUnit.ISource firstFile = Input.FromFile(PathHelper.GetBooksXmlPath()).Build();
            Org.XmlUnit.ISource secondFile = Input.FromFile(PathHelper.GetNewCreatedBooksXmlPath()).Build();
            FileAssert.Exists(new FileInfo(PathHelper.GetNewCreatedBooksXmlPath()));
            Assert.That(firstFile, CompareConstraint.IsIdenticalTo(secondFile));
        }

        [Test]
        [Order(2)]
        public void SerializationEntityToNewBookXmlTest()
        {
            XmlHelper serializer = new XmlHelper();

            var entity = new Catalog()
            {
                Date = DateTime.Now,
                Books = new List<Book>()
                {
                    new Book()
                    {
                        Id = "123identy",
                        Author = "someAuthor",
                        Description = "some big description",
                        Genre = Genre.Horror,
                        Isbn = "124234fdg435352fs",
                        PublishDate = DateTime.Now.AddYears(-2),
                        Publisher = "Denis Shcharbakou",
                        RegistrationDate = DateTime.Now.AddYears(-1),
                        Title = "Hello Title"
                    },

                    new Book()
                    {
                        Id = "123identy123454",
                        Author = "someAuthor3",
                        Description = "some big description3",
                        Genre = Genre.Fantasy,
                        PublishDate = DateTime.Now.AddYears(-4),
                        Publisher = "Denis Shcharbakou2",
                        RegistrationDate = DateTime.Now.AddYears(-3),
                        Title = "Hello Title2"
                    },
                }
            };

            serializer.Serialize<Catalog>(entity);

            FileAssert.Exists(new FileInfo(PathHelper.GetNewCreatedBooksXmlPath()));
        }
    }
}