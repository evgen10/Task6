using MyXMLLibrary.Abstract;
using MyXMLLibrary.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyXMLLibrary.Exceptions;
namespace MyXMLLibrary
{
    static class XMLUtilite
    {
        public static void CheckFields(ICatalogItem item)
        {
            Type type = item.GetType();

            var properties = type.GetProperties().Where(p => p.GetCustomAttribute<RequiredAttribute>() != null);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    if (property.GetValue(item) == null || string.IsNullOrEmpty(property.GetValue(item).ToString()))
                    {
                        throw new RequiredProperiesException($"Required property {property.Name} does not has value");
  
                    }

                }
            }

        }



        public static int? ConvertToInt(string str)
        {
            try
            {
                return XmlConvert.ToInt32(str);
            }
            catch (FormatException)
            {

                return null;
            }
        }


        public static DateTime? ConvertToDateTime(string str)
        {
            try
            {
                return XmlConvert.ToDateTime(str, "yyyy-MM-dd");
            }
            catch (FormatException)
            {

                return null;
            }
        }



    }
}
