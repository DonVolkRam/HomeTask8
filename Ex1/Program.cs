using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex1
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            List<string> Title = new List<string>
            {
                "DeclaringType",
                "Name",
                "PropertyType",
                "CanRead",
                "CanWrite",
                "Value"
            };
            List<string> TimeProp = new List<string>
            {
                "Date",
                "Day",
                "DayOfWeek",
                "DayOfYear",
                "Hour",
                "Kind",
                "Millisecond",
                "Minute",
                "Month",
                "Second",
                "Ticks",
                "TimeOfDay",
                "Year"
            };

            Console.WriteLine($"{Title[1],-12}{Title[2],-20}{Title[3],-9}{Title[4],-9}{Title[5],-9}");
            Console.WriteLine();
            foreach (var a in TimeProp)
            {
//                Console.Write($"{GetPropertyInfo(dateTime, a).DeclaringType,-17 }");
                Console.Write($"{GetPropertyInfo(dateTime, a).Name,-12 }");
                Console.Write($"{GetPropertyInfo(dateTime, a).PropertyType,-20 }");
                Console.Write($"{GetPropertyInfo(dateTime, a).CanRead,-9 }");
                Console.Write($"{GetPropertyInfo(dateTime, a).CanWrite,-9 }");
                Console.WriteLine($"{GetPropertyInfo(dateTime, a).GetValue(dateTime, null),-9 }");
            }
            Console.ReadKey();
        }
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }
    }
}
