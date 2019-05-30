using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace CountXMLSize
{
    class XMLParser<T> 
    {

       

        public XMLParser()
        {
           
        }
        

        public T SetAllValues(XmlReader xmlreader, T itemForParse)
        {
            foreach (var item in itemForParse.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var fieldName = item.Name;
                var fieldValue = xmlreader.GetAttribute(fieldName);

                SetValueFromName(fieldName, fieldValue,  itemForParse);
            }
            return itemForParse;
        }
        public void SetValueFromName(string fieldName, string fieldValue, T itemForParse)
        {
            var field = GetFieldFromName(fieldName, itemForParse);

            var typeName = field.FieldType.Name;
            switch (typeName)
            {
                case nameof(Int32):
                    {
                        field.SetValue(itemForParse, int.Parse(fieldValue));
                        break;
                    }
                case nameof(String):
                    {
                        field.SetValue(itemForParse, fieldValue);
                        break;
                    }
                case nameof(DateTime):
                    {
                        field.SetValue(itemForParse, DateTime.Parse(fieldValue));
                        break;
                    }
                default: { field.SetValue(itemForParse, fieldValue); break; }
            }
        }
        private FieldInfo GetFieldFromName(string fieldName, T itemForParse)
        {
            return itemForParse.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        }
    }
}
