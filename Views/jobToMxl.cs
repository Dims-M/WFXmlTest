using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFXmlTest.JobXml;

namespace WFXmlTest.Views
{
   
    public partial class jobToXml : Form
    { 
        
        JobInXml servis; 

        public jobToXml()
        {
            InitializeComponent();
        }

        //кнопка добавить. Из текстбоксов перенос в таблицу
        private void button2_Click(object sender, EventArgs e)
        {
            servis = new JobInXml();

            if (textBox1.Text == "" || numericUpDown1.Value <=1)
            {
                string tempLog = "[Заполните все поля, перед добавлением в таблицу вывода!!!!] \n";
                servis.WrateText(tempLog);
                MessageBox.Show(tempLog);
                ClearTextBox();
            }

            else
            {
                int n = dataGridView1.Rows.Add(); // создаем новую строку
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text; // столбец Name
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value; // Age
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text; // Programmer
                ClearTextBox();
                servis.WrateText("Данные добавлены в таблицу DataGridView");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Сохранение файла в XML формат
        private void button5_Click(object sender, EventArgs e)
        {
            SaveXmlToFileDoc();
        }


        //Методы

        private void ClearTextBox()
        {
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            textBox2.Text = "";
        }

        /// <summary>
        /// Метод создания и сохранения XML файла
        /// </summary>
        private void SaveXmlToFileDoc()
        {
            servis = new JobInXml();
            
            try
                {
                    DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                    DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных

                    dt.TableName = "JobXml"; // название таблицы
                    dt.Columns.Add("Name"); // название колонок
                    dt.Columns.Add("Age");
                    dt.Columns.Add("Comment");
                    ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                    foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                    {
                        DataRow row = ds.Tables["JobXml"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                        row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                        row["Age"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                        row["Comment"] = r.Cells[2].Value; //то же самое с третьими столбцами
                        ds.Tables["JobXml"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                    }

                    ds.WriteXml("Data.xml"); // создание файла XML из  DataSet
                    servis.WrateText("[XML файл (Data.xml) успешно сохранен в папке с программой]");
                    MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
                }
                catch (Exception ex)
                {
                servis.WrateText("[Ошибка при создании(DataSet) и сохранении XML файл на жесткий диск] \n"+ ex);
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
                }
            
        }

    }
}
