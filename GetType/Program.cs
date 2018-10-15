using System;
using System.Collections.Generic;
using System.Reflection;
class Program
{
    static PropertyInfo GetPropertyInfo(object obj, string str)
    {
        return obj.GetType().GetProperty(str);
    }
    static void Main()
    {
        if (false)
        {
            // Используется для получения объекта System.Type для типа.
            // Выражение typeof принимает следующую форму:
            Type type = typeof(int);
            Console.WriteLine(type);
            // Для получения типа выражения во время выполнения можно
            // воспользоваться методом платформы.NET GetType, как показано в следующем примере:
            int i = 0;
            Type type2 = i.GetType();
            Console.WriteLine(type2);
            Console.Read();
        }
        DateTime dateTime = new DateTime();
        //dateTime.DayOfWeek

        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek"));
        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").DeclaringType);
        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").Name);
        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanRead);
        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanWrite);
        Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null));
        Console.ReadKey();
    }
}
