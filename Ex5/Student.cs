using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ex5
{
    public class Student
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastName;
        /// <summary>
        /// Имя
        /// </summary>
        public string firstName;
        /// <summary>
        /// Наименования ВУЗа
        /// </summary>
        public string university;
        /// <summary>
        /// Наименование факультета
        /// </summary>
        public string faculty;
        /// <summary>
        /// Номер Курса
        /// </summary>
        public int course;
        /// <summary>
        /// Наименование кафедры
        /// </summary>
        public string department;
        /// <summary>
        /// Номер группы
        /// </summary>
        public int group;
        /// <summary>
        /// Город прописки студента
        /// </summary>
        public string city;
        /// <summary>
        /// Возраст студента
        /// </summary>
        public int age;

        public Student() { }
        // Создаем конструктор
        public Student(string firstName, string lastName, string university,
        string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public static void SaveAsXmlFormat(List<Student> obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }
        //"..\\..\\Students.csv"
        public static bool LoadAsCsvFormat(ref List<Student> list, string fileName)
        {
            bool firstRead = true;            
            
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                try
                {
                    if (firstRead)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            string[] temp = sr.ReadLine().Split(';');
                        }
                        firstRead = false;
                    }
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], 
                        int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]) , s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                }
            }
            return true;
        }
    }
}
