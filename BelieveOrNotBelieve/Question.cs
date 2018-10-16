using System;
namespace BelieveOrNotBelieve
{
    /// <summary>
    /// Класс описывающий структуру вопроса
    /// </summary>
    [Serializable]
    public class Question
    {
        /// <summary>
        /// Защищеный текст
        /// </summary>
        private string text;
        
        /// <summary>
        /// Защищенный ответ на вопрос
        /// </summary>
        private bool trueFalse;
        
        /// <summary>
        /// Доступ к полю текста
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Доступ к полю ответа на вопроса
        /// </summary>
        public bool TrueFalse
        {
            get { return trueFalse; }
            set { trueFalse = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Question()
        {
        }

        /// <summary>
        /// Создание объекта вопрос
        /// </summary>
        /// <param name="text">Текст вопроса</param>
        /// <param name="trueFalse">Отевт на вопрос</param>
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
}
