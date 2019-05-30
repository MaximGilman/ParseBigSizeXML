using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CountXMLSize
{
    class Program
    {

        static int milCounter = 1;
        static void Main(string[] args)
        {
            string elementName;


            var path = @"";
            List<IXMLParserable> itemsFromXml = new List<IXMLParserable>();
            XMLParser<IXMLParserable> itemsParser = new XMLParser<IXMLParserable>(new AddressObject());
            using (XmlReader myReader = XmlReader.Create(path))
            {
                Console.WriteLine("Start Reading...");
                while (myReader.Read())
                {
                    // reads the element
                    if (myReader.NodeType == XmlNodeType.Element)
                    {
                        elementName = myReader.Name; // the name of the current element
                        if (elementName == "House")
                        {
                            itemsFromXml.Add(readItem(itemsParser, myReader));
                            CheckCount(itemsFromXml);
                           
                        }
                        if (elementName == "Object")
                        {
                            itemsFromXml.Add(readItem(itemsParser, myReader));
                            CheckCount(itemsFromXml);
                            
                        }

                    }

                    // reads the element value
                    else if (myReader.NodeType == XmlNodeType.Text)
                    {
                        var a = myReader.Value;

                    }



                }
            }


        }

       
        private static IXMLParserable readItem(XMLParser<IXMLParserable> parser, XmlReader myReader)
        {

            House house = new House();
            return parser.SetAllValues(myReader);


        }

        

        private static void CheckCount<T>(IEnumerable<T> collection, int ceil = 1000000)
        {
            if (collection.Count() / (ceil) > 0)
            {
                Console.WriteLine(@"Move above {ceil} -" + collection.Count() * milCounter);
                milCounter++;

                Console.WriteLine("Write to File...");
                WriteToSCV(collection);
                collection = new List<T>();

            }
        }
        private static void WriteToSCV<T>(IEnumerable<T> itemsFromXml, char separator = '\n')
        {
            string path = (itemsFromXml.First() is House) ? "House.csv" : "AddressObject.csv";
            using (StreamWriter f = File.AppendText("House.csv"))
            {
                foreach (var item in itemsFromXml)
                {
                    f.WriteLine(item.ToString() + separator);
                }
                f.Close();
            }

        }
    }
}
