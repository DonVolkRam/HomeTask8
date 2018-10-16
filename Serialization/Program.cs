using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{

    class Program
    {
        static void SaveAsXmlFormat(Student obj, string fileName)
        {
            // Сохранить объект класса Student в файле fileName в формате XML
            // typeof(Student) передает в XmlSerializer данные о классе.
            // Внутри метода Serialize происходит большая работа по постройке
            // графа зависимостей для последующего создания xml-файла.
            // Процесс получения данных о структуре объекта называется рефлексией.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));
            // Создаем файловый поток(проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            // В этот поток записываем сериализованные данные(записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }
        static Student LoadFromXmlFormat(string fileName)
        {
            Student obj = new Student();
            // Считать объект Student из файла fileName формата XML
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));
            Stream fStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read);
            obj = (xmlFormat.Deserialize(fStream) as Student);
            fStream.Close();
            return obj;
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Age = 20;
            student.firstName = "Иван";
            student.lastName = "Иванов";
            SaveAsXmlFormat(student, "data.xml");
            student = LoadFromXmlFormat("data.xml");
            //Console.WriteLine("{0} {1} { 2} " , 
            //    student.firstName , student.lastName , student.Age );
            string text = $"{student.firstName} {student.lastName} {student.Age}";
            Console.WriteLine(text);
//            Console.WriteLine($"{student.firstName} {student.lastName} {student.Age}");
            Console.ReadKey();
        }
    }
}
