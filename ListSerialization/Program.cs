using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace XMLSerializer_List
{
    [Serializable]
    public class Student
    {
        // Чтобы поля можно было сериализовать, они должны быть открытыми
        public string firstName;
        public string lastName;
        // Если поле не открыто, оно не будет сериализоваться
        int age;
        // Если мы хотим не нарушать принцип инкапсуляции и при этом сериализовать поле, 
        //то должны реализовать доступ к нему через публичное свойство
        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }
        // Если есть отличный от конструктора по умолчанию конструктор, 
        // то пустой конструктор автоматически не создается
        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        //...в этом случае для сериализации требуется самим создать пустой конструктор
        public Student()
        {
        }
    }
    class Program
    {
        static void SaveAsXmlFormat(List<Student> obj, string fileName)
        {
            // Сериализовать список объектов не представляется большой проблемой
            // Дело в том, что все объекты в C# наследуются от класса Object,
            // который представляет собой дерево объектов
            // подробней читайте у Эндрю Троелсена “Язык программирования C# 5.0”
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            // Создаем файловый поток (проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            // В этот поток записываем сериализованные данные (записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }
        static void LoadFromXmlFormat(ref List<Student> obj, string fileName)
        {
            // Считать класс List<Student> из файла fileName формата XML
            // Обратите внимание, что этот пример показывает нам, что List<Student> 
            //не более, чем класс, его структура более сложная и для ее понимания потребуется некоторый опыт
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read);
            obj = (List<Student>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("Иван", "Иванов", 20));
            list.Add(new Student("Петр", "Петров", 21));
            SaveAsXmlFormat(list, "data.xml");
            LoadFromXmlFormat(ref list, "data.xml");
            foreach (var v in list)
            {
                Console.WriteLine("{0} {1} {2}", v.firstName, v.lastName, v.Age);
            }
            Console.ReadKey();
        }
    }
}