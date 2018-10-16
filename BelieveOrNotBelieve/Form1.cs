using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок(не
// создана база данных, обращение к несуществующему вопросу, открытие слишком большого
// файла и т.д.).
// б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив
// другие «косметические» улучшения на свое усмотрение.
// в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия,
// авторские права и др.).
// г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных
// (элемент SaveFileDialog).

//Выполнил Волков Кирилл Александрович
namespace BelieveOrNotBelieve
{
    /// <summary>
    /// Окно работы с вопросами
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Экземпляр базы данных с вопросами
        /// </summary>
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик пункта меню New
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }

        /// <summary>
        /// Обработчик пункта меню Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                if (database[0] != null)
                    tboxQuestion.Text = database[0].Text;
            }
        }

        /// <summary>
        /// Обработчик пункта меню Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }

        // 3. г)* Добавить пункт меню Save As, в котором можно выбрать имя 
        // для сохранения базы данных (элемент SaveFileDialog).
        /// <summary>
        /// Обработчик пункта меню Save as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TrueFalse newdatabase = new TrueFalse(sfd.FileName, database);
                if (newdatabase != null) newdatabase.Save();
                else MessageBox.Show("База данных не создана");
            }
        }

        /// <summary>
        /// Обработчик пункта меню Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 2. Создайте простую форму на котором свяжите свойство Text 
        // элемента TextBox со свойством Value элемента NumericUpDown
        /// <summary>
        /// Обработчик события изменения значения numericUpDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database!=null && database.Count > 0)
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
                textBox1.Text = nudNumber.Value.ToString();
            }
        }

        /// <summary>
        /// Обработчик кнопки Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            else
            {
                database.Add((database.Count + 1).ToString(), true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
            }
        }

        /// <summary>
        /// Обработчик кнопки Удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database != null && database.Count > 0)
            {
                if (nudNumber.Maximum == 1 || database == null) return;
                database.Remove((int)nudNumber.Value);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
            }
        }

        /// <summary>
        /// Обработчик кнопки Сохранить (вопрос)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (database != null && database.Count > 0)
            {
                database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
            }
        }

        private void aboitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия программы 1.3\n" +
                "Автор Волков Кирилл\n" +
                "CopyRight  VKA©", "О программе");
        }
    }
}


