using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using MyXMLLibrary.Parsers;
using MyXMLLibrary.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MyXMLLibrary
{
    public class CatalogXML
    {
        private IXMLWriter writer;
        private IXMLParser xmlParser;

        public void WriteTo(Stream outStream, IEnumerable<ICatalogItem> catalogItems)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(outStream, new XmlWriterSettings { Indent = true }))
            {
                xmlWriter.WriteStartElement("catalog");
                xmlWriter.WriteAttributeString("unloadingTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                foreach (var item in catalogItems)
                {
                    InitializeWriter(item.GetType());

                    if (writer != null)
                    {
                        writer.Write(xmlWriter, item);
                    }
                }

                xmlWriter.WriteEndElement();

            }

        }       

        public IEnumerable<ICatalogItem> ReadFrom(Stream outStream)
        {
            using (XmlReader xmlReader = XmlReader.Create(outStream))
            {
                foreach (var element in GetXMLElements(xmlReader))
                {
                    InitializeParser(element.Name.ToString());
                    yield return xmlParser.ParseFrom(element);

                }
            }
        }

        private void InitializeWriter(Type type)
        {
            if (typeof(Book) == type)
            {
                writer = new BookXMLWriter();
                return;
            }
            if (typeof(Newspaper) == type)
            {
                writer = new NewspaperXMLWriter();
                return;
            }
            if (typeof(Patent) == type)
            {
                writer = new PatentXMLWriter();
                return;
            }

            writer = null;

        }

        private void InitializeParser(string name)
        {
            if (name == "book")
            {
                xmlParser = new BookParser();
                return;
            }
            if (name == "newspaper")
            {
                xmlParser = new NewspaperParser();
                return;
            }
            if (name == "patent")
            {
                xmlParser = new PatentParser();
                return;
            }
        }
        
        private IEnumerable<XElement> GetXMLElements(XmlReader reader)
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    XElement element = XElement.ReadFrom(reader) as XElement;

                    if (element != null)
                    {
                        yield return element;
                    }
                }
            }
        }

    }
}
