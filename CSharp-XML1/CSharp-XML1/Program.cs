using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace CSharp_XML1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello XML");

           

            createXml();

            readXml();

            Console.ReadLine(); //prevents CMD from closing
        }

        static void createXml()
        {

            XmlWriterSettings myXmlSettings = new XmlWriterSettings();
            //myXmlSettings.NewLineOnAttributes = true;
            myXmlSettings.Indent = true;


            XmlWriter myXmlWriter = XmlWriter.Create("test.xml", myXmlSettings);

            myXmlWriter.WriteStartDocument();

            myXmlWriter.WriteStartElement("Element");

            myXmlWriter.WriteStartElement("ChildElement");

            myXmlWriter.WriteAttributeString("Attribute", "attContent");
            myXmlWriter.WriteString("contents");

            myXmlWriter.WriteEndElement(); //ends childElement

            myXmlWriter.WriteEndElement();

            myXmlWriter.WriteEndDocument();
            myXmlWriter.Close();
        }

        static void readXml()
        {
            try
            {
                XmlReader myXmlReader = XmlReader.Create("test.xml");

                while (myXmlReader.Read())
                {
                    if ((myXmlReader.NodeType == XmlNodeType.Element) && (myXmlReader.Name == "ChildElement"))
                    {
                        if (myXmlReader.HasAttributes)
                        {
                            //Console.WriteLine(myXmlReader.GetAttribute("currency") + ": " + myXmlReader.GetAttribute("rate"));
                        }
                        Console.WriteLine("ChildElement found!");
                        Console.WriteLine(myXmlReader.Value.ToString());
                    }

                }
            }
            catch
            {
                Console.WriteLine("File not found!!");    
            }


            

        }






    }
}
