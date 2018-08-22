using MyXMLLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class ItemViewer
    {

        public void ShowItems(IEnumerable<object> items)
        {         

            foreach (var item in items)
            {
                Type itemType = item.GetType();
                Console.WriteLine(itemType.Name);

                var properties = itemType.GetProperties();

                foreach (var property in properties)
                {
                    if(property.PropertyType.Name == typeof(IEnumerable<object>).Name)
                    {
                        ShowItems((IEnumerable<object>)property.GetValue(item));
                    }
                    else
                    {
                        Console.WriteLine($"{property.Name}: {property.GetValue(item)}");
                    }
                    
                    
                }
                Console.WriteLine();               

            }

        }



       
    }
}
