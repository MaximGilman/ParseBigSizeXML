using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace CountXMLSize
{
    class XMLParser<T> where  T : new()
    {

        public T itemForParse;

        public XMLParser(T itemForParse)
        {
            this.itemForParse = itemForParse;
        }
        public XMLParser()
        {
            itemForParse = new T();
        }

        public T SetAllValues(XmlReader xmlreader)
        {
            foreach (var item in itemForParse.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var fieldName = item.Name;
                var fieldValue = xmlreader.GetAttribute(fieldName);

                SetValueFromName(fieldName, fieldValue);
            }
            return itemForParse;
        }
        public void SetValueFromName(string fieldName, string fieldValue)
        {
            var field = GetFieldFromName(fieldName);

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
        private FieldInfo GetFieldFromName(string fieldName)
        {
            return itemForParse.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        }
    }
}
