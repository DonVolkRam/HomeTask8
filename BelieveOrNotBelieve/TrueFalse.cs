using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace BelieveOrNotBelieve
{
    class TrueFalse
    {
        /// <summary>
        /// Имя файла с вопросами
        /// </summary>
        string fileName;

        /// <summary>
        /// Колекция вопросов
        /// </summary>
        List<Question> list;

        /// <summary>
        /// доступ к имени файла
        /// </summary>
        public string FileName
        {
            set { fileName = value; }
        }
        
        /// <summary>
        /// Инициализация экземпляра по имени файла
        /// </summary>
        /// <param name="fileName">имя файла с вопросами</param>
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        /// <summary>
        /// Инициализация экземпляра по имени файла и уже существующему экземпляру
        /// </summary>
        /// <param name="fileName">имя файла с вопросами</param>
        /// <param name="db">колекция вопросов</param>
        public TrueFalse(string fileName, TrueFalse db)
        {
            this.fileName = fileName;
            list = db.list;
        }

        /// <summary>
        /// Метод добавления вопроса
        /// </summary>
        /// <param name="text">Текст вопроса</param>
        /// <param name="trueFalse">Ответ на вопрос</param>
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        /// <summary>
        /// удаления вопроса из колекции
        /// </summary>
        /// <param name="index">порядковый номер вопроса</param>
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }

        /// <summary>
        /// Индексатор - свойство для доступа к закрытому объекту
        /// </summary>
        /// <param name="index">Порядковый номер</param>
        /// <returns>возвращает экземпляр вопроса</returns> 
        public Question this[int index]
        {
            get { if (list.Count > 0) return list[index]; else return null; }
        }

        /// <summary>
        /// Метод сохранения колекции вопросов в базе
        /// </summary>
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        /// <summary>
        /// метод загрузки коллекции из базы
        /// </summary>
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        /// <summary>
        /// Доступ к счетчику вопросов
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }
    }
}

