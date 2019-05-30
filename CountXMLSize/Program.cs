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
        static void Main(string[] args)
        {
            string elementName;

            List<House> HousesFromXml = new List<House>();
            int milCounter = 1;
            using (XmlReader myReader = XmlReader.Create(@"AS_HOUSE_20190519_842e11dc-5c02-4250-baf1-4b03b38b3d6a.xml"))
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
                            House house = new House();
                            HousesFromXml.Add(house.SetAllValues(myReader));

                            if (HousesFromXml.Count() / (1000000) > 0)
                            {
                                Console.WriteLine("Move above million -" + HousesFromXml.Count()*milCounter);
                                milCounter++;

                                Console.WriteLine("Write to File...");

                                WriteToSCV(HousesFromXml);
                                HousesFromXml = new List<House>();
                            }
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


        // Concurrently do other work and then wait 
        // for the data to be written and verified.
    
    static   void EndWrite(IAsyncResult asyncResult)
    {
        FileStream fStream = (FileStream)asyncResult.AsyncState;
        fStream.EndWrite(asyncResult);
        fStream.Close();
    }
    private   static void WriteProcces(List<House> housesFromXml, char separator = '\n')
        {
            FileStream sourceStream = new FileStream("House.csv",
          FileMode.Append, FileAccess.Write, FileShare.None,
          bufferSize: 4096, useAsync: true);
            
                foreach (var item in housesFromXml)
                {
                    byte[] encodedText = Encoding.Unicode.GetBytes(item.ToString() + separator);
                    IAsyncResult asyncResult = sourceStream.BeginWrite(
                                   encodedText, 0, encodedText.Length,
                                   new AsyncCallback(EndWrite),
                                   sourceStream);
                }
                
             
        }
        private static void WriteToSCV(List<House> housesFromXml,char separator = '\n')
        {
            using (StreamWriter f = File.AppendText("House.csv"))
            {
                foreach (var item in housesFromXml)
                {
                    f.WriteLine(item.ToString() + separator);
                }
                f.Close();
            }
            
        }
    }
}
