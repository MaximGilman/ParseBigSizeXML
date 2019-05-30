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
       static string pathToCSV = "value.csv";

        static int milCounter = 1;
        static List<IXMLParserable> itemsFromXml = new List<IXMLParserable>();
        static void Main(string[] args)
        {
            File.Delete(pathToCSV);
            string elementName;

            //var type = new House();
           var type = new AddressObject();
            var path = @"";
            
            XMLParser<IXMLParserable> itemsParser = new XMLParser<IXMLParserable>();
            using (XmlReader myReader = XmlReader.Create(path))
            {
                Console.WriteLine("Start Reading...");
                while (myReader.Read())
                {
                    // reads the element
                    if (myReader.NodeType == XmlNodeType.Element)
                    {
                        elementName = myReader.Name; // the name of the current element


                        if (elementName == "House"|| elementName == "Object" )
                        {
                            readItem(itemsParser, myReader, type);
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

       
        private static void readItem(XMLParser<IXMLParserable> parser, XmlReader myReader, IXMLParserable item)
        {


            itemsFromXml.Add(parser.SetAllValues(myReader, item));


        }

        

        private static void CheckCount<T>(IEnumerable<T> collection, int ceil = 1000000)
        {
            if (collection.Count() / (ceil) > 0)
            {
                Console.WriteLine($"Move above {ceil} -" + collection.Count() * milCounter);
                milCounter++;

                Console.WriteLine("Write to File...");
                WriteToSCV(collection);
                collection = new List<T>();
                
            }
        }
        private static void WriteToSCV<T>(IEnumerable<T> itemsFromXml, char separator = '\n')
        {
            
          
            using (StreamWriter f = File.AppendText(pathToCSV))
            {
                foreach (var item in itemsFromXml)
                {
                    f.Write(item.ToString() + separator);
                }
                f.Close();
            }

        }
    }
}
